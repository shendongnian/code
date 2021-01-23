    public class xyz : ISessionService
        {
            public string AddCustomer(AddCustomerRequest addCustomerRequest)
            {   
                using (SessionService service = new SessionService())
                { 
                    response = service.AddCustomer(addCustomerRequest);
                }
                return response;
            }
    }
