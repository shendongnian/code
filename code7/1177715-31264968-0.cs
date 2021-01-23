    public class TestPacklineOrderManagementService
    {
        public class TestSetProduct {
            IPackLineOrderRepository _packLineOrderRepository;
            IRawProductRepository _rawProductRepository;
            // etc
            public TestSetProduct() {
                _packLineOrderRepository = Substitute.For<IPackLineOrderRepository>();
                _packLineOrderRepository.GetActive(Arg.Any<PackLine>()).Returns(x => null);
                _rawProductRepository = Substitute.For<IRawProductRepository>();
                // etc
            }
            [Fact]
            public void CreateNewProductWhenNoPacklineOrderIsAvailable()
            {
                // Any test specific setup...               
                _packlineOrderManagementService.SetProduct(1,1);
        
                _packLineOrderRepository.Received()
                    .Insert(Arg.Is<PackLineOrder>(x => x.PackLine.Id == 1 
                                                    && x.Product.Id == 1));
            }       
            [Fact]
            public void AuditCreateNewProductWhenNoPacklineOrderIsAvailable()
            {
                _packlineOrderManagementService.SetProduct(1, 1);
        
                _auditRegistrationService.Received()
                    .Audit(Arg.Is<PackLineOrderAudit>(item => 
                                   item.Action == PackLineOrderAction.CreatePacklineOrder));
            }
        }
        public class TestSomeOtherScenario {
            // tests...
        }
    }
