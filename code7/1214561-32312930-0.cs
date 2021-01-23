    public static class MyHelper
    {
        public static ActionResult GetAlbumJSON(AlbumVO album)
        {
            return Controller.Content(
                JsonConvert.SerializeObject(new
                {
                    max_car = @ABookClient.maxCharsProjecName,
                    trans_img = @ABookClient.Transparent_Image,
                    show_description = @ABookClient.Show_Product_Description,
                    product_type = "Album",
                    obj = CreateObjAlbumVO(album),
                })
            );
        }
    }
    public class AlbumController : Conrtoller
    {
        public ActionResult GetAlbums(int id)
        {
            var album = Context.GetAlbum(id);
            var serializedResult = MyHelper.GetAlbumJSON(album);
            return Content(serializedResult);
        }
    }
