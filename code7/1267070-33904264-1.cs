    //To get this : <a href="/Foo/FooActionMethodName">Foo Link Text</a>
    
    //Your action link should be
    <ul>
        <li>@Html.ActionLink("Foo Link Text", "FooActionMethodName", "FooController")</li>
    </ul>
    
    //Your controller should be
    public class FooController
    {
     publics ActionResult FooActionMethodName()
     {
        
      return View();
     }
    }
