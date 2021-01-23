    abstract class Request {
        protected Request(string name) {
            Name = name;
        }
    
        public string Name { get; private set; }
    	public Dictionary<string, string> Args { get; set; }
    }
    
    sealed class AuthenticationRequest : Request
    {
        public AuthenticationRequest() : base("AuthenticationRequest") {
        }
    
        public string UserName { get; set; }
        public string Password { get; set; }
    }
