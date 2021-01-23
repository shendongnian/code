    public FileResult getFile(string CsvName)
    {
       //Add businees logic here
       byte[] fileBytes = System.IO.File.ReadAllBytes(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Uploads/records.csv"));
       string fileName = CsvName;
       return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
    }
