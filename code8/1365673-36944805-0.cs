    [TestClass]
    public class MyClassTest
    {
        [TestMethod]
        public async Task MyClass_ReturnsCorrectValues()
        {
            // Arrange
            var m = new Mock<MyClass>();
            m.Setup(x => x.IsKing())
                .Returns(Task.FromResult(true));
            m.Setup(x => x.IsQueen())
                .CallBase();
            // Act
            var isKing = await m.Object.IsKing();
            var isQueen = await m.Object.IsQueen();
            // Assert
            Assert.IsTrue(isKing); // true
            Assert.IsFalse(isQueen); // false
        }
    }
    public class MyClass
    {
        public virtual async Task<bool> IsKing()
        {
            return await Task.FromResult(false);
        }
        public virtual async Task<bool> IsQueen()
        {
            return await Task.FromResult(false);
        }
    }
