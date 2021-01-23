    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        [RequiredParameters("category","name")]
        public IActionResult Get(Request request)
        {
            if(ModelState.IsValid)
                return Json(request);
    
            return BadRequest(ModelState);
        }
    }
