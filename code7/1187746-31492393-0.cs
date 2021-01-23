    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    namespace Tests
    {
        [TestFixture]
        public class Tests
        {
            [Test]
            public void ShouldDoSomething()
            {
                Mock<ICollectionSelector> mockCollectionsSelector = new Mock<ICollectionSelector>();
                mockCollectionsSelector
                    .Setup(s => s.SelectRandomFrom(It.Is<IEnumerable<int>>(fs => fs.All(f => true))))
                    .Returns((IEnumerable<int> fs) => fs.ElementAt(1));  
                    //.Returns<IEnumerable<int>>(fs => fs.ElementAt(1)); // this also works and is more readable I guess
                var selector = mockCollectionsSelector.Object;
                var number = selector.SelectRandomFrom(new[] {1, 2, 3, 4, 5, 6, 7});
                Assert.IsTrue(number == 2);
            }
        }
        public interface ICollectionSelector
        {
            int SelectRandomFrom<T>(IEnumerable<T> @is);
        }
    }
