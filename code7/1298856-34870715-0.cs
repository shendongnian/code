    [TestFixture]
    public class RomanNumeralConverter_Tests
    {
       [TestCase("I", 1)]
       [TestCase("II", 2)]
       [TestCase("III", 3)]
       [TestCase("IV", 4)]
       [TestCase("V", 5)]
       [TestCase("VI", 6)]
       // etc...
       public void Convert_returns_decimal_representation(string roman, int expectedDecimal)
       {
          var result = Program.Convert(roman);
          Assert.AreEqual(expectedDecimal, result);
       }
    }
