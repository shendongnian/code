                public static Customer GetFromRecord(IDataReader reader, int rownum)
            {
                Customer customer = new Customer();
                customer.Address = reader.GetString(0, string.Empty);
                customer.City = reader.GetString(1, string.Empty);
                customer.CompanyName = reader.GetString(2, string.Empty);
                customer.ContactName = reader.GetString(3, string.Empty);
                customer.ContactTitle = reader.GetString(4, string.Empty);
                customer.Country = reader.GetString(5, string.Empty);
                customer.Fax = reader.GetString(6, string.Empty);
                customer.Id = reader.GetString(7, string.Empty);
                customer.Phone = reader.GetString(8, string.Empty);
                customer.PostalCode = reader.GetString(9, string.Empty);
                customer.Region = reader.GetString(10, string.Empty);
                return customer;
            }
