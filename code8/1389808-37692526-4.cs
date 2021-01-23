    public class Order {
        private readonly IWarehouseProvider provider;
    
        public int Items { get; private set; }
    
        public Order(IWarehouseProvider provider) {
            this.provider = provider;
        }
    
        public void AddOrderItems(int numberOfItems) {
            //get a pre-loaded warehouse
            var warehouse = provider.GetWarehouse();
            warehouse.RemoveStock(numberOfItems);
            Items += numberOfItems;
        }
    }
