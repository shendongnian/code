    [PrincipalPermission(SecurityAction.Demand)] //<-- REMOVE Authenticated = true
    class DumbClass
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "ffff")] //<-- this passes (but shouldn't)
        public string EchoMethod(string input)
        {
            return input;
        }
    }
