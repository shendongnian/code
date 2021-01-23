    public class Wrapper<TClient>
    {
        TClient Client;
        public TResult Invoke<TArg, TResult>(Func<TClient, Func<TArg, TResult>> action, TArg arg)
        {
            return action(Client)(arg);
        }
    }
