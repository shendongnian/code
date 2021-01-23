            [BsonIgnoreExtraElements]
            public class UnwindedOrderItem
            {
                public OrderItem OrderItems { get; set; }
            }
    
            var agg = database.GetCollection<Order>("Order")
                    .Aggregate()
                    .Unwind<Order, UnwindedOrderItem>(x => x.OrderItems)
                    .Group(x=>x.OrderItems.ProductId, g => new
                    {
                        Id = g.Key,
                        Suma = g.Sum(x=>x.OrderItems.PriceExclTax)
                    })
                    .ToListAsync().Result;
