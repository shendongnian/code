    //To get this : <a href="/Foo/FooAction">Foo Link Text</a>
    //Your action link should be
    <ul>
        <li>@Html.ActionLink("Foo Link Text", "FooActionMethodName", "FooController")</li>
    </ul>
    
    //Your controller should 
    public class FooController
    {
     publics ActionResult FooActionMethodName()
     {
        
      return View();
     }
    }
