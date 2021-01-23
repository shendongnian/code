    class Account {
        protected string accfilepath;
    
        public Account(IPathProvider pathProvider) {
            accfilepath = pathProvider.MapPath("~/files/");
        }
    }
