    [assembly: InternalsVisibleTo("MyService.UnitTests")]
    public class MyService : IMyService
    {
    private readonly string mSchemaPath;
    private readonly string mXmlPath; 
     public MyService()
            : this(
                Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "MyDataRecords.xml"),
                Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "schema_0.1.xsd"))
        {
            
        }
    internal MyService(string xmlPath,string schemaPath)
    {        
        try
        {
             mXmlPath=xmlPath;
             mSchemaPath=schemaPath;
  
            //load xml document
            mXDocument = Xdocument.Laod(mXmlPath);
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
