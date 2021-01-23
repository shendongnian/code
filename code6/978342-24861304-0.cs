    public static class Extensions {
      public static int[] SplitByDigits(this int value) {
        value = Math.Abs(value); // undefined behaviour for negative values, lets just skip them
        // Initialize array of correct length
        var intArr = new int[(int)Math.Log10(value) + 1];
        for (int p = intArr.Length - 1; p >= 0; p--)
        {
          // Fill the array backwards with "last" digit
          intArr[p] = value % 10;
          // Go to "next" digit
          value /= 10;
        }
        return intArr;
      }
    }
