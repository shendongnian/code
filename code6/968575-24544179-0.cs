    public class MyService : IMyService
    {
        private readonly Func<string, XDocument> _xdocumentLoader;
        private readonly string mSchemaPath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data",
            "schema_0.1.xsd");
        private readonly string mXmlPath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data",
            "MyDataRecords.xml");
        private XDocument mXDocument;
        public MyService(): this(XDocument.Load)
        {
        }
        public MyService(Func<string, XDocument> xdocumentLoader)
        {
            _xdocumentLoader = xdocumentLoader;
            try
            {
                //load xml document
                mXDocument = XDocument.Load(mXmlPath);
                if (mXDocument == null)
                {
                    throw new Exception("Null returned while reading xml file");
                }
            }
            catch (Exception e)
            {
                //my exception management code
            }
        }
        public List<MyRecord> GetAllRecords()
        {
            ////fetch records from xDocument
            mXDocument.Save();
        }
        public void AddRecord(MyRecord record)
        {
            ////add record
            mXDocument.Save();
        }
    }
