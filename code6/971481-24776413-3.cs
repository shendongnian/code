    public class AspNetUserContext : IUserContext
    {
        public bool IsAdministrator
        {
            get 
            { 
                return HttpContext.Current != null && 
                    (bool?)HttpContext.Current.Session["isadmin"] == true;
            }
        }
    }
