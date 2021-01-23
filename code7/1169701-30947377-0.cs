    public class Blacklist : AuthorizeAttribute {
        private List<string> RolesList;
        public string Roles {
            get {
                string roles = "";
                if (RolesList!= null && RolesList.Count > 0) {
                    int counter = 0;
                    foreach (string role in RolesList) {
                        counter++;
                        if (counter == RolesList.Count)
                            roles = role;
                        else 
                            roles += role + ",";
                    }
                }
                return roles;
            }
            set {
                RolesList = new List<string>();
                string[] roles = value.Split(',');
                foreach (string role in roles) {
                    RolesList.Add(role);
                }
            }
        }
    //constructor 
        public Blacklist () {
            RolesList = new List<string>();
        }
    
        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            bool result = true;
            if (httpContext == null) {
                throw new ArgumentNullException("httpContext");
            }
            foreach (string role in RolesList) {
                if (httpContext.User.IsInRole(role)) {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
