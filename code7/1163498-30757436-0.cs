    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Data();
            obj.setData("First", "Last");
            obj.GetDataToXml();
            Console.ReadLine();
        }
    }
    class Data
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public void setData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public XDocument GetDataToXml()
        {
            XDocument doc = new XDocument(
               new XElement("FirstName ", FirstName),
               new XElement("LastName", LastName));
            return doc;
        }
    }
