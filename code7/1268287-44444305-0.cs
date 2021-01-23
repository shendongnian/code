    private ICustomerFacade _customerFacade;
    
    public MyController(ICustomerFacade customerFacade)
    {
         _customerFacade = customerFacade;
    }
    
    public async Task<IHttpActionResult> GetByIdAsync(Guid id){
         return Ok(_customerFacade.getCustomer(id));
    }
