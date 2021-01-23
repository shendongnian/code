    class Clerk : User { }
    class Manager : User { }
    internal class User
    {
        public User() { }
        public string Name { get; set; }
        
        public void Select()
        {
            var list = new List<string>() {"Jack", "Martin"};
            Type thisType = GetType();
            MethodInfo method = thisType.GetMethod("GetQueryable").MakeGenericMethod(thisType);
            method.Invoke(this, new object[] {list});
        }
        public IQueryable<TEntity> GetQueryable<TEntity>(List<string> includes = null) where TEntity : User, new()
        {
            if(includes != null)
            {
                Console.WriteLine(typeof(TEntity));
                var entity = new List<TEntity>(includes.Count);
                entity.AddRange(includes.Select(item => new TEntity {Name = item}));
                return entity.AsQueryable();
            }
            return null;
        }
    }
    class Program
    {
        static void Main()
        {
            User usr = new Manager();
            usr.Select();
        }
    }
