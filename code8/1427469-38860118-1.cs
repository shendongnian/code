    public class FuncDb1SessionProvider : IDb1SessionProvider
    {
        Func<ISession> provider;
        public FuncDb1SessionProvider(Func<ISession> sessionProvider) {
            this.sessionProvier = provider; 
        }
        public ISession Session => provider();
    }
