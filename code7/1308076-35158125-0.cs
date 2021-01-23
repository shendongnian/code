    [TestCaseSource(nameof(TestMethodOneSource))]
    public void TestMethodOne(int x, int y, int expected)
    {
       Assert.That(x + y, Is.EqualTo(expected));
    }
    public static IEnumerable<object[]> TestMethodOneSource() =>
        ReadExcel(nameof(TestMethodOne));
    private static  IEnumerable<object[]> ReadExcel(string method)
    {
        // Open and start reading Excel
        for(var row in rows)
        {
            if(row[0] == method)
            {
                // Return objects minus the method
                yield return new [] {row[1], ..., row[n]};
            }
        }
     }
