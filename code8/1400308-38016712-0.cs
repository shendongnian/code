    public class Writer
    {
      //... other class methods
      public void GeneratePdfAsync(QuotationResponse response)
      {
        var currentPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
        ...
      }
    }
