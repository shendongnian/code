    public class DownloadController : Controller
    {
     [HttpPost]
     public async Task<ActionResult> CsvDownload(string fileName)
     {
           byte[] data = await Task.Run(() => GetCSVData(fileName));
            return File(data, "text/csv", fileName);
     }
    }
    
      
