    [TestFixture]
    public class Given_A_Warehouse_With_20_Items
    {
        private Order _order;
        private Mock<IWarehouseRepo> _warehouseRepo;
        private Warehouse _warehouse;
    
        [SetUp]
        public void When_An_Order_Is_Placed() {
            _warehouse = new Warehouse() { Items = 20 };
            _warehouseRepo = new Mock<IWarehouseRepo>();
            _warehouseRepo.Setup(repo => repo.Warehouse).Returns(_warehouse);
            
            _order = new Order(_warehouseRepo.Object);
            _order.AddOrderItems(5);
        }
    
        [Test]
        public void Then_The_Order_Now_Has_5_Items() {
            Assert.That(_order.Items, Is.EqualTo(5));
        }
    
        [Test]
        public void Then_The_Warehouse_Now_Has_15_Items() {
            Assert.That(_warehouse.Items, Is.EqualTo(15));
        }
    }
    
