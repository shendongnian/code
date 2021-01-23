    public static class Repository {
        public static List<Order> GetOrders() {
            return new List<Order> { 
                new Order(){ Id=0, Date = DateTime.Now.AddDays(-1), 
                    Items = new List<OrderItem>{
                        new OrderItem(){ Id=0, Name="A"},
                        new OrderItem(){ Id=1, Name="B"},
                    }
                },
                new Order(){ Id=1, Date = DateTime.Now, 
                    Items = new List<OrderItem>{
                        new OrderItem(){ Id=0, Name="A"},
                        new OrderItem(){ Id=1, Name="B"},
                        new OrderItem(){ Id=1, Name="C"},
                    }
                }
            };
        }
    }
    public class Order {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<OrderItem> Items { get; set; }
    }
    public class OrderItem {
        public int Id { get; set; }
        public string Name { get; set; }
    }
