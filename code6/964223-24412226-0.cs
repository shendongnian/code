    [HttpPost]
    [AllowAnonymous]
    [ActionName("save")]
    public bool SaveOrders(Data model)
    {
       //model is populated, and you have access to ModelState
    }
    public class Data
    {
        // the JSON to Model mapper match is case-insensitive
        public List<int> ProductIds { get; set; }
        public List<decimal> NewPrices { get; set; }
        public long DateInTicks { get; set; }
    }
