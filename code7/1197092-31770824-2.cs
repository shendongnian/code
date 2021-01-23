        static void Main(string[] args)
                {
                    using (var ctx = new CustomerContext())
                    {
                        //ctx.Database.Create(); // This command can be used to create the database using the code first class
                        ctx.CustomerAddresses.Add(new CustomerAddress
                        {
                            AddressType = new AddressType
                            {
                                AddressTypeId = 1,
                                AddressTypeDescriptiom = "Test"
                            },
                            Customer = new Customer
                            {
                                CustomerId = 1,
                                FirstName = "Oshadha"
                            },
                            Address = new Address
                            {
                                Line1 = "Line 1",
                                City = "Dubai"
                            },
                            DateFrom = DateTime.Now,
                            DateTo = DateTime.Now
                        });
        
                        ctx.SaveChanges();
                    }
                }
