    public class ServerVariables : IServerVariable {
        public string Name {
            get {
                return HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
            }
        }
    }
