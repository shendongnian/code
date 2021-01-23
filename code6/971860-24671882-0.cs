    public class GetVisitorImageController : ApiController
    {
        [Route("GetVisitorImage/{id}")]
        [HttpGet]
        public string Get(string id)
        {
            string[] authorization = Request.Headers.Authorization.ToString().Split('|');
            string PartnerId = Request.Headers.GetValues("PartnerId").First();
            string DeviceId = Request.Headers.GetValues("DeviceId").First();
            System.Drawing.Image visitorimage = VisitorFunctions.GetVisitorImage(authorization[0], authorization[1], id, PartnerId, DeviceId);
            MemoryStream memStream = new MemoryStream();
            visitorimage.Save(memStream, ImageFormat.Jpeg);
            byte[] imageBytes = memStream.ToArray();
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
