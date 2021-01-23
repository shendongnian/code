    public class BaseApiController : ApiController
    {
         private readonly ILogger _logger;
         public BaseApiController(ILogger logger)
         {
            _logger = logger;
         }
         protected override void Initialize(HttpControllerContext controllerContext)
          {
             _logger.log("somes stuff");
             base.Initialize(controllerContext);
          }
    }
