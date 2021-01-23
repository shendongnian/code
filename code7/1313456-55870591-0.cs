    using (var scope = new TransactionScope(TransactionScopeOption.Required))
    {
     // Save to database here.
    scope.TransactionCompleted += (sender, args) => { bus.Publish(new EntityCreatedEvent()); };
     // Event is already published at this point.
     scope.Complete();
    }
