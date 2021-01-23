    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
    {
        _myContext1.Delete(organisation);
        _myContext2.Delete(orders);
        _userManager.Delete(user);
        scope.Complete();
    }
