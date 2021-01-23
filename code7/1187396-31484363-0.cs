    static class Extensions
    {
      public static bool IsEqualTo(this FlintlockDTO expected, Flintlock actual) 
      {
        return expected.GName == actual.GoodName && expected.SharedPropertyName == actual.SharedPropertyName;
      }
    }
