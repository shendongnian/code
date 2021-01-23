    public class SalesOrderBuilder : EntityBuilder<SalesOrder>
    {
        public SalesOrder SalesOrder { get; set; }
        public SalesOrderBuilder()
        {
            SalesOrder = new SalesOrder();
            WithOrderNumber();
        }
        public SalesOrderBuilder(Id id)
            : this() { Id = id; }
        #region Fluent Methods
        public SalesOrderBuilder WithOrderNumber(string orderNumber = null)
        {
            orderNumber = orderNumber ?? "2";
            SalesOrder.OrderNumber = orderNumber;
            return this;
        }
        #endregion // Fluent Methods
        protected override SalesOrder BuildInternal() { return SalesOrder; }
    }
