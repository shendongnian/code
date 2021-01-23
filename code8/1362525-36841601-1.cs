    [TestClass]
    public class MoqSetupWithListParameterTests : MiscUnitTests {
        //m_Items is a static list I filled in the Class Initialize, and is not empty. 
        static IEnumerable<Item> m_Items = Enumerable.Range(1, 10).Select(i => new Item());
        //The mock is also static. 
        static Mock<IWebRequestManager> WebRequestManagerMock = new Mock<IWebRequestManager>();
        [TestMethod]
        public async Task Items_Count_Should_Equal_Orders_Count() {
            //Arrange
            var expected = 3;
            //Orders is also not empty when I debug the test.
            var m_Orders = Enumerable.Range(1, expected).Select(i => new Order());
            WebRequestManagerMock
                .Setup(x => x.GetItemsAsync(It.IsAny<IEnumerable<Order>>()))
                .Returns<IEnumerable<Order>>(orders => Task.FromResult(m_Items.Take(orders.Count())));
            var sut = WebRequestManagerMock.Object;
            //Act
            //When I call GetItemsAsync I get expected count.
            var actual = await sut.GetItemsAsync(m_Orders);
            //Assert
            Assert.AreEqual(expected, actual.Count());
        }
        public interface IWebRequestManager {
            Task<IEnumerable<Item>> GetItemsAsync(IEnumerable<Order> enumerable);
        }
        public class Order { }
        public class Item { }
    }
