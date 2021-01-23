    public class FileUploadPlaceholder
    {
        static private string[] uploadPathArray = new string[] { "~/import1", "~/import2", "~/import3" };
        static private int uploadPathPointer = 0;
        static private int uploadPathPointerMax = 2;
        static public string uploadPath()
        {
            return uploadPathArray[uploadPathPointer];
        }
        static public void cycleUploadPath()
        {
        //the below will be thread safe once I get further along
            if (uploadPathPointer < uploadPathPointerMax)
            {
                uploadPathPointer += 1;
            }
            else
            {
                uploadPathPointer = 0;
            }
        //the above will be thread safe once I get further along
        }
    }
    //[Authorize]
    public class FileUploadController : ApiController
    {
        public async Task<List<string>> PostAsync()
        {
            if (Request.Content.IsMimeMultipartContent())
            {
                string uploadPath = HttpContext.Current.Server.MapPath(FileUploadPlaceholder.uploadPath());
    [...]
