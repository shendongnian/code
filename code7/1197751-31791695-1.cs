    public class SearchModel
    {
        public string Q { get; set; }
    }
    public IHttpActionResult Search([FromUri] SearchModel model)
    {
        return ModelState.IsValid
            ? Ok(model.Q ?? "null")
            : (IHttpActionResult) BadRequest(ModelState);
    }
