    class Users
    {
        private static Hashtable users = new HashTable();
               
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
