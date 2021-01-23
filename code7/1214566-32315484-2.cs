    public class AlbumController : Conrtoller
    {
        public ActionResult GetAlbums(int id)
        {
            var album = Context.GetAlbum(id);
            var model = new AlbumModel(album);
            return Json(model);
        }
    }
