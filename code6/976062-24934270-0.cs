    public class DownloadController : Controller
    {
        public ActionResult GetFile()
        {
            ...
            mem.Position = 0;
    
            return File(
                mem, 
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
                "result.xlsx");
        }
    }
