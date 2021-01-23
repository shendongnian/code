    public class MyControllerV0 : ApiController {
      [Route("/api/v0/foo")]
      public async Task<IHttpActionResult> V0() {
    
    } 
    }
    
    public class MyControllerV1 : MyControllerV0 {
      [Route("/api/v1/foo")]
      public async Task<IHttpActionResult> V1() {
    
    } 
    }
