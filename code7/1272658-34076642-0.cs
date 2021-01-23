    [TestFixture]
    public class SomeObjectTests
    {
        [TestCaseSource(typeof(TestSomeObjectValueData),"TestCases")]
        public double TestSomeObjectValue(SomeObject so)
        {
            return so.Value;
        }    
    }
    public class TestSomeObjectValueData
    {
      public static IEnumerable TestCases
      {
        get
        {
          yield return new TestCaseData( new SomeObject(0.0) ).Returns( 0.0 );
        }
      }  
    }
