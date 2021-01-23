    [TestClass]
    public class MoqSetupWithListParameterTests : MiscUnitTests {
        [TestMethod]
        public async Task Items_Count_Should_Equal_Orders_Count() {
            //Arrange
            var m_Orders = Enumerable.Range(1, 3).Select(i => new Order());
            var m_Items = Enumerable.Range(1, 10).Select(i => new Item());
            var WebRequestManagerMock = new Mock<IWebRequestManager>();
            WebRequestManagerMock
                .Setup(x => x.GetItemsAsync(It.IsAny<IEnumerable<Order>>()))
                .Returns<IEnumerable<Order>>(orders => Task.FromResult(m_Items.Take(orders.Count())));
            var sut = WebRequestManagerMock.Object;
            //Act
            var actual = await sut.GetItemsAsync(m_Orders);
            //Assert
            Assert.AreEqual(m_Orders.Count(), actual.Count());
        }
        public interface IWebRequestManager {
            Task<IEnumerable<Item>> GetItemsAsync(IEnumerable<Order> enumerable);
        }
        public class Order { }
        public class Item { }
    }
