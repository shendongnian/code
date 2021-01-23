    public class CalculatorTests  
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 1.2M, 2.1M, 3.3M },
                new object[] { -4.000M, -6.123M, -10.123M }
            };
        [Theory]
        [MemberData(nameof(Data))]
        public void CanAddTheoryMemberDataProperty(decimal value1, decimal value2, decimal expected)
        {
            var calculator = new Calculator();
    
            var result = calculator.Add(value1, value2);
    
            Assert.Equal(expected, result);
        }
    }
