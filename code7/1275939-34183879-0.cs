    public class ValuesController : ApiController
    {
         public async Task<IHttpActionResult> Post()  
         {
        if (!Request.Content.IsMimeMultipartContent())
        {
            return BadRequest();
        }
        var provider = new MultipartMemoryStreamProvider();
        
        string root = System.Web.HttpContext.Current.Server.MapPath("~/Files/");
        await Request.Content.ReadAsMultipartAsync(provider);
 
        foreach (var file in provider.Contents)
        {
            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
            byte[] fileArray = await file.ReadAsByteArrayAsync();
 
            using (System.IO.FileStream fs = new System.IO.FileStream(root + filename, System.IO.FileMode.Create))
            {
                await fs.WriteAsync(fileArray, 0, fileArray.Length);
            }
        }
        return Ok();
    }
}
