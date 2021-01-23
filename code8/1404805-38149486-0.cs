    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;
    
    namespace UnitTestProject
    {
        [TestClass]
        public class UnitTest
        {
            public class SomeObject
            {
                public virtual void AddOne(List<string> aList) { }
            }
    
            [TestMethod]
            public void SomeTest()
            {
                // Arrange
                var mock = new Mock<SomeObject>();
    
                mock.Setup(so => so.AddOne(It.IsAny<List<string>>()))
                    .Callback<List<string>>(l => l.Add("derp"));
    
                var target = mock.Object;
                var list = new List<string>();
    
                // Act
                target.AddOne(list);
    
                // Assert
                Assert.IsTrue(list.Contains("derp"));            
            }
        }
    }
