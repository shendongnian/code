    [TestFixture]
    public class SomeObjectTests
    {
        [TestCaseSource(typeof(TestSomeObject),"TestCasesValue")]
        public double TestSomeObjectValue(SomeObject so)
        {
            return so.Value;
        }
        [TestCaseSource(typeof(TestSomeObject),"TestCasesValueString")]
        public string TestSomeObjectValueString(SomeObject so)
        {
            return so.ValueString;
        }
    }
    public class TestSomeObject
    {
      public static IEnumerable TestCasesValue
      {
        get
        {
            yield return new TestCaseData( new SomeObject(0.0) ).Returns( 0.0 );
            yield return new TestCaseData( new SomeObject(1.0) ).Returns( 1.0 );
        }
      }
      public static IEnumerable TestCasesValueString
      {
        get
        {
            yield return new TestCaseData( new SomeObject(0.0) ).Returns( "0.0" );
            yield return new TestCaseData( new SomeObject(1.0) ).Returns( "1.0" );
        }
      }
    }
