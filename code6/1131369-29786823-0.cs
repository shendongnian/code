    [TestFixture]
    public class CoffeeStrengthEstimatorTests
    {
        private CoffeeStrengthEstimator _estimator;
        [SetUp]
        public void SetUp()
        {
            // common Arrange
            _estimator = new CoffeeStrengthEstimator();
        }
        [Test]
        [TestCase(1, CoffeeStrength.Light)]
        [TestCase(2, CoffeeStrength.Medium)]
        [TestCase(3, CoffeeStrength.Strong)]
        public void EstimateCoffeeStrength_Returns_Expected_CoffeeStrength_For_Button_Pressed_1_2_or_3(int buttonPressed,
            CoffeeStrength expectedCoffeeStrength)
        {
            // Act
            var coffeeStrength = _estimator.EstimateCoffeeStrength(buttonPressed);
            // Assert
            Assert.AreEqual(expectedCoffeeStrength, coffeeStrength);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(4)]
        public void EstimateCoffeeStrength_Throws_ArgumentException_When_Button_Pressed_Not_1_2_or_3(int buttonPressed)
        {
            // Act and Assert
            Assert.Throws<ArgumentException>(() => _estimator.EstimateCoffeeStrength(buttonPressed));
        }
    }
