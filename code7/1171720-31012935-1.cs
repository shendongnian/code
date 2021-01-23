    $.post('/NMISProduct/Index', { name: 'tyler',hello: 'world' }, function(data) {
        console.log(data);
    });
    [HttpPost]
    public ActionResult Index(FormData submitData)
    {
        return Json(submitData);
    }
    public class FormData 
    {
        public string Name { get; set; }
        public string Hello { get; set; }
    } 
