    [RoutePrefix("myapi")]
    public class MyController : ApiController
    {       
        [Route("update")]
        [HttpPost]
        public UpdateFeatureResponse UpdateFeature(UpdateFeatureResuest reqResuest)
        {
            return new UpdateFeatureResponse { IsSuccess = true };
        }
        
        [Route("delete")]
        [HttpPost]
        public DeleteFeatureResponse DeleteFeature(DeleteFeatureRequest request)
        {
            return new DeleteFeatureResponse{ IsSuccess = true };
        }
    
    }
