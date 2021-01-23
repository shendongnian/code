     public Order ChangeOrderSimple(Guid guid, IEnumerable<JsonModelItem> items, string Comments, bool isReserve, DateTime? DeliveryDate = null)
            {
                decimal total = 0;
                int row = 1;
                Dictionary<int, int> codes = items.ToDictionary(p => p.ProductId,p=>p.Count);
                var OrderToChange = _orders.GetAll(q => q.GuidIn1S == guid).Include(o => o.OrderDetails).FirstOrDefault();
                OrderToChange.Comments = Comments;
                OrderToChange.isReserve = isReserve;
                OrderToChange.DeliveryDate = DeliveryDate;
             
       
                var OrderDetails = OrderToChange.OrderDetails.ToList();
    
                List<OrderDetail> OrderDetailsChanged = new List<OrderDetail>();
            
                for (int i = 0; i < OrderDetails.Count; i++)
                {
                    var item = OrderDetails[i];
                    //    item = OrderD.OrderDetails[i];
                    var result = codes.ContainsKey(item.ProductId);
                                    
                    
                    if (result)
                    {
                        OrderDetail detail = new OrderDetail
                        {
                            RowNumber = ++row,
                            ProductId = item.ProductId,
                            Count = codes[item.ProductId],
                            Price = item.Price,
                            OrderId = item.OrderId
                        };
                        OrderDetailsChanged.Add(detail);
                    }
                }
            
                OrderToChange.OrderDetails = OrderDetailsChanged;
                OrderToChange.CalculateTotal();
            
                _orders.Update(OrderToChange);
                return OrderToChange;
            }
