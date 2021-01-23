    public ActionResult Index()
            {
                var customer = new Customer
                {
                    Name = "Name",
                    Surname = "Surname",
                    Email = "email@email.com",
                    Mobile = "mobile...",
                    Customer_CustomerSpecialConcern = new List<Customer_CustomerSpecialConcern>
                    {
                        new Customer_CustomerSpecialConcern
                        {
                            Value = true
                        },
                        new Customer_CustomerSpecialConcern
                        {
                            Value = true
                        }
                    }
                };
    
                return View(customer);
            }
