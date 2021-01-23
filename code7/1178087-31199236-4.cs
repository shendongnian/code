    class Users
    {
        private Hashtable users;
        private static Users instance;
               
        private Users()
        {
             users = new HashTable();
        }
        public static Users Instance 
        {
            get
            {
                if (instance == null)
                    instance=new Users();
                return instance;
            }
        }
        public void addNewUser(int id, string name)
        {
            if (!users.ContainsKey(id))
                users.Add(id, name);
            else users[id] = name;
        }
    
        public int countUsers()
        {
            return users.Count;
        }    
    }
