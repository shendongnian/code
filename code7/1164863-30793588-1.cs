    public class ImgController : Controller
    {
        
        [Route("~/img/embed/{*filename}")]
        public ActionResult Embed(string filename)
        {
            byte[] content = ResourceLoader.Load(filename);
            string mime = MimeMapping.GetMimeMapping(filename);
            return File(content, mime);
        }
    }
