    public class Foo
    {
    public string MemberId {get; set;} 
    public string Email {get; set;} 
    public string Name {get; set;} 
    public string RedirectUrl {get; set;} 
    }
    public ActionResult SendNotification(Foo foo)
