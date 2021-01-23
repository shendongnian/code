        var client = new customerCustomerRepositoryV1PortTypeClient();
        client.Endpoint.Binding = new BasicHttpBinding();
        
        HttpRequestMessageProperty hrmp = new HttpRequestMessageProperty();
        hrmp.Headers.Add("Authorization", "Bearer " + yourAccessToken);
        
        OperationContextScope contextScope = new OperationContextScope(client.InnerChannel);
        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = hrmp;
        
        CustomerCustomerRepositoryV1GetByIdResponse response = client.customerCustomerRepositoryV1GetById(
        	new CustomerCustomerRepositoryV1GetByIdRequest() { 
        		customerId = 1 
        	}
        );
        Console.WriteLine(response.result.firstname);
    
    
