    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
    public interface IPredicate<T>
    {
        bool IsValid(T entity);
    }
    public class UserPredicate : IPredicate<User>
    {
        /* built-in predicates */
        public static UserPredicate Adult = new UserPredicate(u => u.Age >= 18);
        public static UserPredicate NoAddress = new UserPredicate(u => string.IsNullOrEmpty(u.Address));
        public Func<User, bool> Predicate { get; private set; }
        public UserPredicate(Func<User, bool> predicate)
        {
            this.Predicate = predicate;
        }
        bool IPredicate<User>.IsValid(User entity)
        {
            return this.Predicate(entity);
        }
    }
