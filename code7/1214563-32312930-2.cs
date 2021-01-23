    public static class MyHelper
    {
        public static object GetAlbum(AlbumVO album)
        {
            return new
                {
                    max_car = @ABookClient.maxCharsProjecName,
                    trans_img = @ABookClient.Transparent_Image,
                    show_description = @ABookClient.Show_Product_Description,
                    product_type = "Album",
                    obj = CreateObjAlbumVO(album),
                };
        }
    }
    public class AlbumController : Controller
    {
        public ActionResult GetAlbums(int id)
        {
            var album = Context.GetAlbum(id);
            var convertedResult = MyHelper.GetAlbum(album);
            return Json(convertedResult);
        }
    }
