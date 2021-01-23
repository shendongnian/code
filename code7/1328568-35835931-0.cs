    var scope = new TransactionScope(TransactionScopeOption.RequiresNew,
	new TransactionOptions() { IsolationLevel =	IsolationLevel.ReadUncommitted);
    using (scope)
    {
	  try
	  {
	      ProcessClient();
	      ProcessClientPerson();
	      ProcessGuardian();
	      ProcessAddress();
	      ProcessEmail();
	      ProcessPhones();
	      ProcessChildren();
  	    scope.Complete();
  	  }
  	  catch (System.Data.Entity.Validation.
			       DbEntityValidationException ex)
	  {
      [...] handle validation errors etc [...]
      }
    }
