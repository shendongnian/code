    public class MyClass
    {
        public DateTime MyDate { get; set; }
        public string MyXml
        {
            set
            {
                //XML element should contain only one root element
                //<MyXml> element act as root element
                string myXml = "<myXml>"+ value +"</myXml>";
                RootXml = XElement.Parse(myXml);
            }
        }
        public XElement RootXml;
          
    }  
