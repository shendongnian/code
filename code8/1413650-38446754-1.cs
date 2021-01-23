    public class FooController : Controller {
        public IActionResult GetAnonymousObject() {
            var jsonResult = new {
                id = 1,
                name = "Foo",
                type = "Bar"
            };
            return Ok(jsonResult);
        }
        public IActionResult GetAnonymousCollection() {
            var jsonResult = Enumerable.Range(1, 20).Select(x => new {
                id = x,
                name = "Foo" + x,
                type = "Bar" + x
            }).ToList();
            return Ok(jsonResult);
        }
    }
