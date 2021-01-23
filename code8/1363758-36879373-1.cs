    [TestClass]
    public class HmacSha256Tests
    {
        private readonly HmacSha256 _hmac = new HmacSha256();
        [TestMethod]
        public void Hash_GeneratesValidHash_ForInput()
        {
            // Arrange
            string input = "hello";
            string key = "test";
            string expected = "F151EA24BDA91A18E89B8BB5793EF324B2A02133CCE15A28A719ACBD2E58A986";
            // Act
            byte[] output = _hmac.Hash(input, key);
            string outputHex = BitConverter.ToString(output).Replace("-", "").ToUpper();
            // Assert
            expected.Should().Be(outputHex);
        }
    }
