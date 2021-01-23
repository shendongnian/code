    enter var templates = from t in response.Descendants("OrderList")
                                        select new
                                        {
                                            orderId = t.Element("OrderId").Value.ToString(),
                                            orderTitle = t.Element("OrderTitle").Value.ToString(),
                                            DestinationAddress = t.Element("DestinationAddress").Value.ToString(),
                                            PhoneNumber = t.Element("PhoneNumber").Value.ToString()
                                        };code here
