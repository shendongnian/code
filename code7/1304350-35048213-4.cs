        var customer = new Customer { Name = this.CustomerName, Mail = this.CustomerMail };
        try {
            this.customerService.AddCustomer(customer);
            // Add it to Observable<Customer> list so the UI gets updated
            this.Customers.Add(customer);
            // the service should have populated the Id field of Customer when persisting it
            // so we notify all other ViewModels that a new customer has been added
            this.messageBus.Publish(new CustomerCreated() { CustomerId = customer.Id } );
        } catch (SomeSpecificException e) { // Handle the Exception } 
