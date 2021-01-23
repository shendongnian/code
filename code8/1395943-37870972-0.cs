    public List<Customer> GetCustomerDetail(int id)
    {
        return DoIt( () => _internalService.GetCustomer(id) );
    }
    public List<Customer> GetCompanyDetail(int id)
    {
        return DoIt( () => _internalService.GetCompany(id) );
    }
    private T DoIt<T>( Func<T> func )
    {
      _log.debug("xxx");
    
      if(something)
      {
        _log.debug("yyy");
      }
    
      var results = func();
    
      if(results == null) 
      {
        _log.debug("no results");
      }
    
      return results;
    }
