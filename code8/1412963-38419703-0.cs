    public class ImageSaveController : ApiController
    {
        public ImageData Get()
        {
             return new ImageData
             {
                 // insert test data here
             };
        }
    
        [HttpPost]
        public IHttpActionResult InsertImage(ImageData imageData)
        {
            System.Data.SqlClient.SqlConnection conn = null;
            try
            {               
                //Image save to database code here
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotModified, ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return Content(HttpStatusCode.OK,""); 
        }
    }
