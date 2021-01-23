            List<User> UserList = new List<User>();
            User usr = new User();
            usr.id = "1";
            usr.name = "name1";
            User usr2 = new User();
            usr2.id = "2";
            usr2.name = "name2";
            UserList.Add(usr);
            UserList.Add(usr2);
            List<string> userlist = UserList.Select(a => a.id.ToString() +","+ a.name.ToString()).ToList();
            foreach (string str in userlist)
            {
                Console.WriteLine(str);
            }
