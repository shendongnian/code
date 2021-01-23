    var query = from el in document.Root.Elements("Order")
                select new Orders
                {
                    Id = (int) el.Element("Id"),
                    BillingAddress = new BillingAddress
                    {
                        FirstName = (string) el.Element("BillingAddress").Element("FirstName"),
                        LastName = (string) el.Element("BillingAddress").Element("LastName")
                    }
                };
