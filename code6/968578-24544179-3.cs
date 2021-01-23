    public class MyService : IMyService
    {
    private const string AppDataDirectoryName = "App_Data";
    private const string SchemaFileName = "schema_0.1.xsd";
    private const string XmlFileName = "MyDataRecords.xml";
    private readonly Func<string, XDocument> mdocumentLoader;
    private readonly Func<string> mAppDataDirectoryBuilder;
    private readonly string mSchemaPath = "";
    private readonly string mXmlPath = "";
    private XDocument mXDocument;
    
    public MyService() : this(XDocument.Load, () => HostingEnvironment.ApplicationPhysicalPath)
    {
    }
    public MyService(Func<string, XDocument> documentLoader, Func<string> appDataDirectoryBuilder)
    {
        mdocumentLoader = documentLoader;
        mAppDataDirectoryBuilder = appDataDirectoryBuilder;
        try
        {
            var baseDirectory = mAppDataDirectoryBuilder();
            mSchemaPath = Path.Combine(baseDirectory, AppDataDirectoryName, SchemaFileName);
            mXmlPath = Path.Combine(baseDirectory, AppDataDirectoryName, XmlFileName);
            mXDocument = mdocumentLoader(mXmlPath);
            
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
        return null;
        //mXDocument.Save();
    }
    public void AddRecord(MyRecord record)
    {
        ////add record
        // mXDocument.Save(record);
    }
}
