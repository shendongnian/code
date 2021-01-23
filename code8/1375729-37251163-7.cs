    public interface IPredicate<T>
    {
        bool IsValid(T entity);
        IPredicate<T> And(IPredicate<T> another);
        IPredicate<T> Or(IPredicate<T> another);
    }
    public class UserPredicate : IPredicate<User>
    {
        public static UserPredicate Adult = new UserPredicate(u => u.Age >= 18);
        public static UserPredicate NoAddress = new UserPredicate(u => string.IsNullOrEmpty(u.Address));
        private Func<User, bool> _predicate;
        public UserPredicate(Func<User, bool> predicate)
        {
            _predicate = predicate;
        }
        public bool IsValid(User entity)
        {
            return _predicate(entity);
        }
        public IPredicate<User> And(IPredicate<User> another)
        {
            return new UserPredicate(u => this.IsValid(u) && another.IsValid(u));
        }
        public IPredicate<User> Or(IPredicate<User> another)
        {
            return new UserPredicate(u => this.IsValid(u) || another.IsValid(u));
        }
    }
    //usage
    var AdultWithNoAddress = UserPredicate.Adult.And(UserPredicate.NoAddress);
