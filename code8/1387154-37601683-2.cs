    // Helper method to compare - VS Unit Testing Framework
    private static void CompareIEnumerable<T>(IEnumerable<T> one, IEnumerable<T> two, Func<T, T, bool> comparisonFunction)
    {
        var oneArray = one as T[] ?? one.ToArray();
        var twoArray = two as T[] ?? two.ToArray();
        if (oneArray.Length != twoArray.Length)
        {
            Assert.Fail("Collections have not same length");
        }
        for (int i = 0; i < oneArray.Length; i++)
        {
            var isEqual = comparisonFunction(oneArray[i], twoArray[i]);
            Assert.IsTrue(isEqual);
        }
    }
    public void HowToCall()
    {
        // How you need to call the comparer helper:
        CompareIEnumerable(actual, expected, (x, y) => 
            x.Alpha == y.Alpha && 
            x.Beta == y.Beta );
    }
    
