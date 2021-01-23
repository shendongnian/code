    <%@ WebHandler Language="C#" Class="CheckSessionAlive" %>
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.SessionState;
    using System.Web.Script.Serialization;
    public class CheckSessionAlive : IHttpHandler, IRequiresSessionState {
        
        public void ProcessRequest (HttpContext cx) {
            cx.Response.ContentType = "text/json";
            cx.Response.Write(new JavaScriptSerializer().Serialize(new
            {
                Result = cx.Session["SomeRandomValue"] != null ? 1 : -1
            }));
        }
     
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
