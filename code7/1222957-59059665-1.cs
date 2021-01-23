c#
using (var transaction = _myAdaptor.BeginTransaction())
Your mock/fake still needs to return something so the line `transaction.Commit();`
can still execute.  
Normally I'd set the fake of my adapter to return an interface from `BeginTransaction()` at that point (so I can fake that returned object too), but the `DbContextTransaction` returned by `BeginTransaction()` only implements `IDisposable` so there was no interface that could give me access to the `Rollback` and `Commit` methods of `DbContextTransaction`. 
Furthermore, `DbContextTransaction` has no public constructor, so I couldn't just new up an instance of it to return either (and even if I could, it wouldn't be ideal as I couldn't then check for calls to commit or rollback the transaction).
So, in the end I took a slightly different approach and created a separate class altogether to manage the transaction:
c#
using System;
using System.Data.Entity;
public interface IEfTransactionService
{
    IManagedEfTransaction GetManagedEfTransaction();
}
public class EfTransactionService : IEfTransactionService
{
    private readonly IFMDContext _context;
    public EfTransactionService(IFMDContext context)
    {
        _context = context;
    }
    public IManagedEfTransaction GetManagedEfTransaction()
    {
        return new ManagedEfTransaction(_context);
    }
}
public interface IManagedEfTransaction : IDisposable
{
    DbContextTransaction BeginEfTransaction();
    void CommitEfTransaction();
    void RollbackEfTransaction();
}
public class ManagedEfTransaction : IManagedEfTransaction
{
    private readonly IDataContext  _context;
    private DbContextTransaction _transaction;
    public ManagedEfTransaction(IDataContext  context)
    {
        _context = context;
    }
    /// <summary>
    /// Not returning the transaction here because we want to avoid any
    /// external references to it stopping it from being disposed by
    /// the using statement
    /// </summary>
    public void BeginEfTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
    }
    public void CommitEfTransaction()
    {
        if (_transaction == null) throw new Exception("No transaction");
        _transaction.Commit();
        _transaction = null;
    }
    public void RollbackEfTransaction()
    {
        if (_transaction == null) throw new Exception("No transaction");
        
        _transaction.Rollback();
        _transaction = null;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            // free managed resources
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
    }
}
I then inject that service class into whatever classes need to use a transaction.  For example, using the code from the original question:
c#
private readonly DataContext _context;
private readonly IEfTransactionManager _transactionManager;
public MyService(DataContext ctx, IEfTransactionManager transactionManager)
{
    _context = ctx;
    _transactionManager = transactionManager;
}
public void SaveRepositories(Repository repo)
{
    using (_context)
    {
        // Here the transaction creation fails
        using (var managedEfTransaction = _transactionManager.GetManagedEfTransaction())
        {
            try
            {
                managedEfTransaction.BeginEfTransaction();
                DeleteExistingEntries(repo.Id);
                AddRepositories(repo);
                _context.SaveChanges();
                managedEfTransaction.CommitEfTransaction();
            }
            catch (Exception)
            {
                managedEfTransaction.RollbackEfTransaction();
                throw;
            }
        }
    }
}
