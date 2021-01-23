    [Route("api/[controller]")]
    [ApiController]
    public class MyController : MyControllerBase
    {
        [HttpGet]
        [Route("{key}")]
        public IActionResult Get(int key)
        {
            try
            {
                //do something that fails
            }
            catch (Exception e)
            {
                LogException(e);
                return InternalServerError();
            }
        }
    }
    
    public class MyControllerBase : ControllerBase
    {
        public InternalServerErrorObjectResult InternalServerError()
        {
            return new InternalServerErrorObjectResult();
        }
    
        public InternalServerErrorObjectResult InternalServerError(object value)
        {
            return new InternalServerErrorObjectResult(value);
        }
    }
    
    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    
        public InternalServerErrorObjectResult() : this(null)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
