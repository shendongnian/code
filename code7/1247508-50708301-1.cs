    class DumbClass
    {
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)] 
        public DumbClass()
        {
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "ffff")]
        public string EchoMethod(string input)
        {
            return input;
        }
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)] 
        public string OtherMethod(string input)
        {
            return input;
        }
 
    }
