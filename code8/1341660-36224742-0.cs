    public class TriggerApiController : ApiController
    {
    	private readonly ITriggerApiService _triggerApiService;
    
    	public TriggerApiController(ITriggerApiService triggerApiService)
    	{
    		_triggerApiService = triggerApiService;
    	}
    
    	[HttpGet]
    	[Route("api/v1/trigger/{externalID}")]
    	public async Task<IHttpActionResult> GetTrigger(Guid externalID)
    	{
    		var triggerApiModel = await _triggerApiService.GetAsync(externalID);
    
    		if (triggerApiModel != null)
    		{
    			return Ok(triggerApiModel);
    		}
    
    		return NotFound();
    	}
    }
