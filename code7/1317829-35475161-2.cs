    public class ExampleController : Controller
    {
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Test(Foo fooModel)
        { 
            // do your thing...
            return this.View();
        }
    }
    
    <form action="/Example/test" method="POST">
        @Html.AntiForgeryToken()
        <input type="text" name="bar" />
        <input type="submit" value="Submit" />
    </form>
