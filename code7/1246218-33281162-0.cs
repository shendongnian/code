    [SessionState(SessionStateBehavior.Disabled)]
    public class UploadController : Controller
    {
        [HttpPost]
        [ValidateInput(false)]
        public async Task<JsonResult> VideoUpload(string Id)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                // :::::
                await Run(fileStream);
            }
            return Json(new { error = false, message = "File uploaded." });
        }
        public async Task Run(Stream fileStream)
        {
            // :::::
            using (fileStream)
            {
                // A long running method call
                await fileUploadRequest.UploadAsync();
            }
        }
        [HttpGet]
        public JsonResult GetUploadingStatus()
        {
            // :::::
            return Json(new { statusMessage = statusMessage, totalSent = totalSent, totalSize = totalSize }, JsonRequestBehavior.AllowGet);
        }
    }
