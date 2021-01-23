    [Route("Blas")]
    public class BlasController : Controller
    {
        [HttpGet("{fileName}")]
        public ActionResult Index(string fileName)
        {
            return View();
        }
    }
