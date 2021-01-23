    [HttpPut]
    public IHttpActionResult ToggleLinkStatus(RequestModel model)
    {
        // model.IsActive ...
        return Ok();
    }
    public class RequestModel {
        bool IsActive {get;set;}
        Guid LinkGuid {get;set;}
    }
