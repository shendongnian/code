    public class YourController : System.Web.Mvc.Controller {
        public void SomeAction() {
            var bl = new EntityNameBusinessLayer(System.Web.HttpContext.Current.Request);
            var result = bl.RetrieveUserBrowserDetails();
        }
    }
