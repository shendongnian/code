    class Program
    {
        static void Main(string[] args)
        {
            string xmlfilepath = @"xml.xml";
            XDocument xmlsrcdoc = XDocument.Load(xmlfilepath);
            List<Codelang> lstCodelang = new List<Codelang>();
            try
            {
                lstCodelang = xmlsrcdoc.Descendants()
                                           .Elements("prox")
                                           .Select(el => FromXElement<Codelang>(el.Parent))
                                           .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static T FromXElement<T>(XElement element) where T : class, new()
        {
            var typeOfT = typeof(T);
            T value = new T();
            foreach (var subElement in element.Elements())
            {
                var prop = typeOfT.GetProperty(subElement.Name.LocalName);
                if (prop != null)
                {
                    prop.SetValue(value, subElement.Value);
                }
            }
            return value;
        }
    }
