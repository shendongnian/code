    // action
    public class NormalController : Controller
    {
        [HttpPost]
        public IActionResult UltimateModelBinding(
            ModelBindingModel model, 
            [FromServices]IUrlHelperFactory urlHelper)
        {
            return null;
        }
    }
    // model
    public class ModelBindingModel
    {
        [FromBody]
        public RequestModel Body { get; set; }
        [FromForm(Name = "MyField")]
        public string Form { get; set; }
        [FromQuery(Name = "MyQuery")]
        public string Query { get; set; }
        [FromRoute(Name = "id")]
        public int Route { get; set; }
        [FromHeader(Name = "MyHeader")]
        public string Header { get; set; }
    }
    // unit test
    MyMvc
        .Routes()
        .ShouldMap(request => request
            .WithLocation("/Normal/UltimateModelBinding/100?myQuery=Test")
            .WithMethod(HttpMethod.Post)
            .WithJsonBody(new
            {
                Integer = 1,
                String = "MyBodyValue"
            })
            .WithFormField("MyField", "MyFieldValue")
            .WithHeader("MyHeader", "MyHeaderValue"))
        .To<NormalController>(c => c.UltimateModelBinding(
            new ModelBindingModel
            {
                Body = new RequestModel { Integer = 1, String = "MyBodyValue" },
                Form = "MyFieldValue",
                Route = 100,
                Query = "Test",
                Header = "MyHeaderValue"
            },
            From.Services<IUrlHelperFactory>()));
