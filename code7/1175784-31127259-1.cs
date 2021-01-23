    public class SomeClass
    {
        public int InsertUsers(params User[] users)
        {
            using(var context = new DataModel())
            {
                context.Users.AddRange(users);
            }
        }
    }
