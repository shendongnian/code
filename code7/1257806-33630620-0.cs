        public void MyMethod()
        {
            myEntities getUsers = new myEntities ();
            var query = from userTable in getUsers.userTable
                                select userTable;
          
            Parallel.ForEach(query, CreateUser);
        }
        private void CreateUser(userTable account)
        {
            new User(account.userName, account.password);
        }
