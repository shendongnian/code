    private class InternalLibrary
    {
        private readonly List<ConnectionController> _list ;
       
        public InternalLibrary ()
        {
             _list = new List<ConnectionController> { 
                      new ConnectionController() { 
                        UserName = "x", 
                        Password="y",
                        ProjectName="r",
                        Domain = "z", 
                        SQLDatabase = "a", 
                        SQLServer = "b"
                    }
                 };
        }
        public List<ConnectionController> ccList
        {
            get { return _list; }
        }
    }
    
