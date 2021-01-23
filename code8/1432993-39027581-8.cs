    public class YourAspWebPage : System.Web.UI.Page {
        protected void Button_Click(object sender, EventArgs args) {
            var bl = new EntityNameBusinessLayer(this.Request);
            var result = bl.RetrieveUserBrowserDetails();
        }
    }
