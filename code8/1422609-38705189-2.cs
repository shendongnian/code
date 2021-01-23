    public interface IReadOnlyUser
    {
        int xCoor {get;}
        int yCoor {get;}
    }
    internal class ReadOnlyUser : IReadOnlyUser
    {
        private readonly User user;
    
        public ReadOnlyUser(User user)
        {
            this.user = user;
        }
    
        public int xCoor{get { return this.user.xCoor; }}
        public int yCoor{get { return this.user.yCoor; }}
    }
    public IEnumerable<IReadOnlyUser> GetAllUsers()
    {
        return userMapping.Values
            .Select(u => (IReadOnlyUser) new ReadOnlyUser(u));
    }
