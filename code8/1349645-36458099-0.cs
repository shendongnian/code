    // the core model for the user info
    public class UserProfile {
        public int SomeValue {get;set;}
    }
    // a viewmodel for some specific view:
    public class MyViewModel : DomainObject {
        public UserProfile UserProfile {get;set;}
    }
    // from your controller:
    public ActionResult MyAction() {
        var model = repository.GetMyViewModel();
        model.UserProfile = Session["UserProfile"] as UserProfile;
        return View(model);
    }
