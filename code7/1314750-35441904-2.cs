    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Test {
        
        [TestFixture]
        class TestWareHouse {
        
            private WareHouse warehouse = new WareHouse();
            private static String TALISKER = "Talisker";
            private static String HIGHLAND_PARK = "Highland Park";
        
            [SetUp]
            public void SetUp() {
                //reset
                warehouse = new WareHouse();
                warehouse.Add(TALISKER, 50);
                warehouse.Add(HIGHLAND_PARK, 25);
            }
        
            //regular testing
            [Test]
            public void testOrderIsFilledIfEnoughInWarehouse() {
                Order order = new Order(TALISKER, 50);
                order.Fill(warehouse);
                Assert.True(order.isFilled());
                Assert.AreEqual(0, warehouse.GetInventory(TALISKER));
            }
        
             [Test]
            public void testOrderDoesNotRemoveIfNotEnough() {
                Order order = new Order(TALISKER, 51);
                order.Fill(warehouse);
                Assert.False(order.isFilled());
                Assert.AreEqual(50, warehouse.GetInventory(TALISKER));
            }
        
        
            //Now I am trying to do the things with Mock
            [Test]
            public void testOrderIsFilledIfEnoughInWarehouseMock() {
                Order order = new Order(TALISKER, 50);
                //-- Creating a fake ICustomerRepository object
                var warehouseMock = new Mock<WareHouse>();
                //warehouseMock
        
                warehouseMock
                .Setup(m => m.FillIt(TALISKER, 50))
                .Returns(true);
        
                order.Fill(warehouseMock.Object);
        
        
                //-- Assert ----------------------
                Assert.IsTrue(order.isFilled());
        
        
                warehouseMock.Verify(x => x.FillIt(It.IsAny<string>(), It.IsAny<int>()), Times.Exactly(1));
                }
        
            [Test]
            public void testFillingDoesNotRemoveIfNotEnoughInStock() {
                Order order = new Order(TALISKER, 51);
                //-- Creating a fake ICustomerRepository object
                var warehouseMock = new Mock<WareHouse>();
                
                 warehouseMock
                .Setup(m => m.FillIt(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(false);
        
                 order.Fill(warehouseMock.Object);
        
        
                //-- Assert ----------------------
                Assert.IsFalse(order.isFilled());
        
                warehouseMock.Verify(x => x.FillIt(It.IsAny<string>(), It.IsAny<int>()), Times.Exactly(1));
                   
            }
        
          }
    }
