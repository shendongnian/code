    public class question3apiController : ApiController
    {
        public  IHttpActionResult GetFile()
        {
            string FilePath = HttpContext.Current.Server.MapPath("~/images/images.png");
            byte [] myBytes = File.ReadAllBytes(FilePath);
            return Ok(myBytes);
        }
    }
