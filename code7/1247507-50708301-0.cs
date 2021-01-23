    [PrincipalPermission(SecurityAction.Demand, Authenticated = true)] 
    class DumbClass
    {
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)] 
        public DumbClass()
        {
        }
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)] 
        [PrincipalPermission(SecurityAction.Demand, Role = "ffff")]
        public string EchoMethod(string input)
        {
            return input;
        }
    }
