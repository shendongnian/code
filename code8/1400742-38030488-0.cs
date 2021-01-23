    class Group{
        public string GroupName {
            get;set;
        }
        public List<User> Users {
            get; private set;
        }
        public Group(){
            Users = new List<User>();
        }
    }
