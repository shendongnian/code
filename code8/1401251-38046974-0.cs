    [Route("[conroller]/[action]")]
    public class ImagesController
    {
        [HttpGet("/[controller]/{productId:int}/images/{imageId:int}/comments/{commentId:int}")]
        public IActionResult GetComments(int productId, int imageId, int commentId) 
        {
        }
    }
