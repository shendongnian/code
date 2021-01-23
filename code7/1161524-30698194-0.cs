    // Unit of work also implements IDisposable so "using" blocks can be used
    // to discard changes if code doesn't commit changes
    using(IUnitOfWork<T> uow1 = ...)
    {
         // Some stuff like accessing unit of work's repository...
    
         // Then, here's the domain transition to other unit of work:
         using(IUnitOfWork<T2> uow2 = uow1.TransitionTo<T2>())
         {
              // Some other stuff using uow2
    
              using(IUnitOfWork<TN> uow3 = uow2.TransitionTo<TN>()
              {
    
              }
    
         }
         await uow1.CommitAsync();
    }
