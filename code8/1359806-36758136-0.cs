    [TestClass]
    public class MoqVerificationTest {
        [TestMethod]
        public void Moq_Should_Verify_Setup() {
            //Arrange
            var mockAwesome = new Mock<IAwesome>();
            mockAwesome.Setup(x => x.RunSomething()).Verifiable();
            //Act
            var sut = new myclass(mockAwesome.Object);
            sut.MethodUnderTest();
            //Assert
            mockAwesome.Verify();
        }
        public interface IAwesome {
            void RunSomething();
        }
        public class myclass {
            private IAwesome awesomeObject;
            public myclass(IAwesome awesomeObject) {
                this.awesomeObject = awesomeObject;
            }
            public void MethodUnderTest() {
                this.awesomeObject.RunSomething(); //I want to verify that RunSomething was called
            }
        }
    }
