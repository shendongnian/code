    public class VisualStudioApiController : ApiController
    {
        // GET /VisualStudioApi/OpenFile/?path=
        [HttpGet]
        public string OpenFile(string path)
        {
             var fullPath = Path.Combine(
                    Path.GetDirectoryName(
                        OwinVisualStudioApiListenerManager.VisualStudioApi.Solution.FullName),
                    HttpUtility.UrlDecode(path));
              //http://stackoverflow.com/q/5039226/1224069
              OwinVisualStudioApiListenerManager.VisualStudioApi
                    .ExecuteCommand(
                        "File.OpenFile",
                        fullPath);
 
               return "success";
        }
    }
            
