    namespace MyWebAPI.App_Service {
        public class MyActionFilter : System.Web.Http.Filters.ActionFilterAttribute {
            public override void OnActionExecuted(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext) {
                var principal = actionExecutedContext.ActionContext.RequestContext.Principal;
                if(principal != null) {
                    using (var db = new databaseContext()) {
                        var dbUser = (from b in db.AspNetUsers
                                    where b.UserName == principal.Identity.Name
                                    select b).First();
                        dbUser.LastActivity = DateTime.Now;
                        db.SaveChanges();
                    }
                }
            }
        }
    }
