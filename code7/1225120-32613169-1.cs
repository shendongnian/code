    public class FileValidatorTests
    {
        [Fact]
        public void Spike()
        {
            var line = "D|111111|87654321|Bar|BCreace|GBP|24/08/2010";
            var lineItem = LineItem.Parse(line);
            var result = new LineItemValidator().Validate(lineItem);
            Assert.True(result.IsValid);
        }
    }
