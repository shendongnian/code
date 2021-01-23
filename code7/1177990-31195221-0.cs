    $http.post("/api/Checkout/SaveOrderOption", OrderOption)
    [HttpPost]
    [Route("Checkout/SaveOrderOption/{orderOption}")]
    public void SaveOrderOption([FromBody]OrderOption orderOption)
    {
        _Logger.Trace(orderOption.ToJSON());
    }
    public class OrderOption
    {
        public string Xxxx { get; set; }
        public bool Www { get; set; }
        public bool Yyy { get; set; }
    }
