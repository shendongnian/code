    public class MyModel {
        public int ProductID { get; set; }
        public List<int> BrandIDs { get; set; }
    }
    
    public IHttpActionResult Post(MyModel model) {
        var productId = model.ProductID;
        foreach(var brandId in model.BrandIDs) {
            DoSomething(brandId);
        }
        return Ok();    
    }
