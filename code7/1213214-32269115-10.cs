    class PrivilegesViewModel
    {
        public bool CanEdit{get;set;}
        public bool CanRead{get;set;}
        // and so on
    }
    class PostViewModel
    {
        // our model data
        public PrivilegesViewModel Privileges{get;set;}
    }
 
