    partial class User
    {
        public static class Q
        {
            public static Expression<Func<User,bool>> IsStudent
            {
                return x => x.Type == (int)UserTypes.Student;
            }
        }
    }
