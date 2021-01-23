    static class Users
    {
        private static Hashtable ;
    
        static Users()
        {
           users = new Hashtable();
        }
    
        public static void addNewUser(int id, string name)
        {
            if (!users.ContainsKey(id))
                users.Add(id, name);
            else users[id] = name;
        }
    
        public static int countUsers()
        {
            return users.Count;
        }    
    }
