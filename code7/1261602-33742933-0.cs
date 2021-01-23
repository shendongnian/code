    public class SaveModel 
    {
        public string DATA {get; set;}
    }
    [HttpPost]
    [Route("api/SkeltaInterfaceController/SaveWorkflow")]
    public bool SaveWorkflow([FromBody] SaveModel model)
    { ...
