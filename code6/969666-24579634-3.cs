    you can also inherit other interfaces.
    public interface ITransactionService : IDisposable
    {
      IAccount Account{get;set;}
    }
