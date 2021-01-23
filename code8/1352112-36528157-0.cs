    using Math.Library;
    using System;
    using Moq;
    using NUnit.Framework;
    namespace UnitTests {
    [TestFixture]
    public class CMathTests {
        CMath mathObj;
        private IMath _math;
        [SetUp]
        public void Setup() {
            mathObj = new CMath();// no need for this in mocking and its a wrong      approach
            _math = new Mock<IMath>();//initialize a mock object
        }
        [Test]
        public void Add_Numbers9and5_Expected14() {
            Assert.AreEqual(14, mathObj.Add(9, 5));
        }
        [Test]
        public void Subtract_5From9_Expected4() {
            Assert.AreEqual(4, mathObj.Subtract(9, 5));
        }
        [Test]
        public void Multiply_5by9_Expected45() {
            Assert.AreEqual(45, mathObj.Multiply(5, 9));
        }
        [Test]
        public void When80isDividedby16_ResultIs5() {
            Assert.AreEqual(5, mathObj.Divide(80, 16));
        }
        [Test]
        public void When5isDividedBy0_ExceptionIsThrown() {
            Assert.That(() => mathObj.Divide(1, 0),
                Throws.Exception.TypeOf<DivideByZeroException>());
        }
        [Test]
        public void Factorial_Of4_ShouldReturn24() {
            Assert.That(mathObj.Factorial(4), Is.EqualTo(24));
        }
        [Test]
        public void Factorial_Of4_CallsMultiply4Times() {
        int count = 0;
        _math.setup(x =>x.Multiply(It.IsAny<Int>(),It.IsAny<Int>())).Callback(() => count++);
        _math.verify(x =>x.Multiply(),"Multiply is called"+ count+" number of times");
        }
    }
    }
