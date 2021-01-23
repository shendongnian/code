    public class HTMLHelper
        {
            public static void jsAlertAndRedirect(System.Web.UI.Page instance, string Message, string Redirect_URL)
            {
                instance.Response.Write(@"<script language='javascript'>alert('" + Message + "');document.location.href='" + url + "'; </script>");
            }
        }
