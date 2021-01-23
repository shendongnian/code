    class PDFController : Controller
    {
      public ActionResult Download(int id)
      {
        byte[] fileContents;
        // Your code to read the binary file from DB.
        // fileContents = // Populate from DB
        
        return new FileContentResult(fileContents, "application/pdf");
      }
      
    }
