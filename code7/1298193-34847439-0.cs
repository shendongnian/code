    public class DownloadController : Controller
    {
     [HttpPost]
     public async Task<ActionResult> CsvDownload(string fileName)
     {
            byte[] data = GetCSVData(fileName);
            return File(data, "text/csv", fileName);
     }
    }
    
      
