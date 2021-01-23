        public class ViewModel1
    {
        public ObservableCollection<XmlDataProvider> Xmls { get; set; }
        public ViewModel1()
        {
            Xmls = new ObservableCollection<XmlDataProvider>();
            Xmls.Add(GetXml());
            Xmls.Add(GetXml());
        }
        XmlDataProvider GetXml()
        {
            XmlDataProvider dataProvider = new XmlDataProvider();
            XmlDocument doc=new XmlDocument();
            doc.LoadXml(@"<TEST><Name>TESTRUN</Name><SyncByte>ff</SyncByte><SOM>53</SOM><PDADD>7e</PDADD><LENLSB>08</LENLSB></TEST>");
            dataProvider.Document = doc;
            return dataProvider;
        }
    }
    
