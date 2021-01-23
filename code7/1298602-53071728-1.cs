    Customer application = new Customer
            {
                ProductDescription = "Appliances ",
                Fname = "Marisol ",
                Lname = "Testcase "
            
            };
            var JsonOutput = JsonConvert.SerializeObject(application);
