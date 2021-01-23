    public class MainClassFactory
    {
        /// <summary>
        /// Returns MainClass Object from Xaml Code.
        /// </summary>
        public static MainClass LoadMainClass(String xamlAsString)
        {
            StringReader stringReader = new StringReader(xamlAsString.ToString());
    
            XmlReader xmlReader = XmlReader.Create(stringReader);
            object outputMainClass = XamlReader.Load(xmlReader);
    
            return outputMainClass as MainClass;
        }
    }
