    public class Wrapper<TClient>
    {
        TClient Client;
    
        public void Invoke<TArg, TResult>(Func<TClient, Func<TArg, TResult>> action, TArg arg, out TResult result)
        {
            return action(Client)(arg);
        }
    }
