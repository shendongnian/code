    class Sample {
    static void Main(string[] args)
    {
        ReportingService2010 rs = new ReportingService2010();
        rs.Url = "http://<Server Name>" +
            "/_vti_bin/ReportServer/ReportService2010.asmx";
        rs.Credentials = 
            System.Net.CredentialCache.DefaultCredentials;
        Byte[] definition = null;
        Warning[] warnings = null;
        string name = "MyReport.rdl";
        try
        {
            FileStream stream = File.OpenRead("MyReport.rdl");
            definition = new Byte[stream.Length];
            stream.Read(definition, 0, (int)stream.Length);
            stream.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        try
        {
            string parent = "http://<Server Name>/Docs/Documents/";
            CatalogItem report = rs.CreateCatalogItem("Report", name, parent,
                        false, definition, null, out warnings);
            if (warnings != null)
            {
                foreach (Warning warning in warnings)
                {
                    Console.WriteLine(warning.Message);
                }
            }
            else
                Console.WriteLine("Report: {0} created successfully " +
                                  " with no warnings", name);
        }
        catch (SoapException e)
        {
            Console.WriteLine(e.Detail.InnerXml.ToString());
        }
    } }
