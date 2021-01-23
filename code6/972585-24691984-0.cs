    public enum ECacheType
    {
        cache=1, none=2
    }
    public enum EFileType 
    {
        t1=1, t2=2
    }
    public class TestController
    {
        [Route("{type}/{library}/{version}/{file?}/{renew?}")]
        public ActionResult Index2(EFileType type,
                                  string library,
                                  string version,
                                  string file = null,
                                  ECacheType renew = ECacheType.cache)
        {
            return View("Index");
        }
    }
