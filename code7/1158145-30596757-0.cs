    public class WS : System.Web.Services.WebService
    {
    
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public void registerUser()
        {
            try
            {
                if(Session["users"] == null)
                    Session["users"] = new List<User>();
    
                List<User> users = (List<User>)Session["users"];
    
                string s = HttpContext.Current.Request.Form[0].ToString();
                User tempUser = new User();
                tempUser = JsonConvert.DeserializeObject<User>(s);
                users.Add(tempUser);
    
                Session["users"] = users;
            }
            catch(Exception e)
            {
                HttpContext.Current.Response.Write(e.Message);
            }
        }
    }
