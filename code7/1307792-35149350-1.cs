    public class MobilesController:Controller
    {
        AdController ad = new AdContoller();
        public ActionResult SaveMobilesAd()
        {
           //some stuff.
           ad.MyAd(Request);
        }
    }
