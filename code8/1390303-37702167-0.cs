    public class Connection<T>
    {
    }
    public abstract class Client<T, U> where T : Connection<U>
    {
    }
