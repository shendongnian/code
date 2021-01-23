    var query = from el in document.Root.Elements("Order")
                        select new Orders
                        {
                            Id = (int)el.Element("Id"),
                            Names = el.Elements("BillingAddress")
                                      .Select(ba=> 
                                            new { FirstName = (string)ba.Element("FirstName"),
                                                  LastName = (string)ba.Element("LastName")
                                                }
                        };
