    public ServiceRequest[] SomeMethod() {
        //..other code
        TestMVC.GetServiceRequests.serviceRequests[] serviceRequests = svcClient.GetServiceRequests(getServiceRequest).responseData;
        
        return serviceRequests.Select(s=> new ServiceRequest {
            customerName = s.customerName,
            contactName = s.contactName,
            //...etc...
        }).ToArray();
    }
