            while (reader.ReadToFollowing("Order"))
            {               
                order.OrderID = reader.GetAttribute("ID");
                string orderID = reader.Value;
                reader.ReadToFollowing("OrderDate");
                if(reader.Name.Equals("OrderDate"))
                    order.OrderDate = reader.ReadElementContentAsString();
                if (reader.Name.Equals("BuyerID"))
                    order.CustomerID = reader.ReadElementContentAsString();               
                orderList.Add(order);
                while (reader.ReadToFollowing("Item"))
                {
                    OrderDetail i = new OrderDetail();
                    i.OrderID = orderID;                  
                    i.ItemID = reader.GetAttribute("ID");
                    reader.ReadToFollowing("Decscription");
                    if (reader.Name.Equals("Decscription"))
                        i.Description = reader.ReadElementContentAsString();
                    if (reader.Name.Equals("Capacity"))
                        i.Capacity = reader.ReadElementContentAsString();
                    if (reader.Name.Equals("Quantities"))
                        i.Quantity = reader.ReadElementContentAsInt();
                    if (reader.Name.Equals("existingUnitPrice"))
                        i.AskingPrice = reader.ReadElementContentAsDecimal();
                    orderDetailList.Add(i);
                }
            }
