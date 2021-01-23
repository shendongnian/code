    // Fill the DataSet
    DataSet dataSet = new DataSet("tblResources");
    adapter.Fill(dataSet);
    
    //Populate nested class base on DataSet
    var resources = new List<Resource>();
    
    string currentResourceID = string.Empty;
    string currentCustomerID = string.Empty;
    int totalRows = dataSet.Tables[0].Rows.Count;
    
    var resource = new Resource();
    var customer = new Customer();
    var customers = new List<Customer>();
    var appointments = new List<Appointment>();
    bool newResource = false;
    bool newCustomer = false;
    
    for (int i = 0; i < totalRows; i++)
    {
        var resourceID = dataSet.Tables[0].Rows[i]["resourceID"].ToString();
        var resourceName = dataSet.Tables[0].Rows[i]["resourceName"].ToString();
        var customerID = dataSet.Tables[0].Rows[i]["customerID"].ToString();
        var firstName = dataSet.Tables[0].Rows[i]["firstName"].ToString();
        var lastName = dataSet.Tables[0].Rows[i]["lastName"].ToString();
        var appointmentID = dataSet.Tables[0].Rows[i]["appointmentID"].ToString();
        var startDate = dataSet.Tables[0].Rows[i]["startDate"].ToString();
        var endDate = dataSet.Tables[0].Rows[i]["endDate"].ToString();
    
        if (!currentResourceID.Equals(resourceID))
        {
            currentResourceID = resourceID;
    
            resource = new Resource()
            {
                resourceID = resourceID,
                resourceName = resourceName
            };
    
            resources.Add(resource);
    
            newResource = true;
        }
        else
        {
            newResource = false;
        }
    
        if (newResource)
        {
            customers = new List<Customer>();
    
            resource.Customers = customers;
            currentCustomerID = string.Empty;
    
        }
    
        if (!currentCustomerID.Equals(customerID))
        {
            currentCustomerID = customerID;
    
            customer = new Customer()
            {
                customerID = customerID,
                firstName = firstName,
                lastName = lastName
            };
    
    
            customers.Add(customer);
    
            newCustomer = true;
        }
        else
        {
            newCustomer = false;
        }
    
        if (newCustomer)
        {
            appointments = new List<Appointment>();
    
            customer.Appointments = appointments;
    
        }
    
        var appointment = new Appointment()
        {
            appointmentID = appointmentID,
            startDate = startDate,
            endDate = endDate
        };
    
        appointments.Add(appointment);
                        
    }
    
    //Convert nested class to json
    JavaScriptSerializer serializer = new JavaScriptSerializer();
    serializer.MaxJsonLength = Int32.MaxValue;
    var resourceJSON = serializer.Serialize(resources);
