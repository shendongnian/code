     public class Upload : IHttpHandler
    {
        public static readonly JavaScriptSerializer jss = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plan";
       
                var file = context.Request.Files["img"];
               
              
                Image image = System.Drawing.Image.FromStream(file.InputStream);
                context.Response.Write(jss.Serialize(new { status = "success", url = "data:image/jpg;base64," + CroppicUtils.ImageToBase64(image, CroppicUtils.GetImageFormat(image)), width = image.Width, height = image.Height }));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
