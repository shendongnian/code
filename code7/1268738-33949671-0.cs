    class Program
    {
        static void Main(string[] args)
        {
            var wrapper = new Wrapper<Client>();
            var result = wrapper.Invoke<int, string>(c => c.Convert, 5);
        }
    }
    public class Client
    {
        public string Convert(int value)
        {
            return value.ToString();
        }
    }
    public class Wrapper<TClient>
    {
        TClient Client;
        public TResult Invoke<TArg, TResult>(Func<TClient, Func<TArg, TResult>> action, TArg arg)
        {
            return action(Client)(arg);
        }
    }
