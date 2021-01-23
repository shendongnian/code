    public interface IUser {
        string Name { get; set; }
    }
    public interface ISettings<out TUser>
        where TUser : IUser {
    }
    public interface IPage<out TUser>
        where TUser : IUser {
        ISettings<TUser> Settings { get; }
    }
    //...
    public abstract class Page<TUser> : IPage<TUser>
        where TUser : IUser {
        public ISettings<TUser> Settings { get; private set; }
    }
