    [TestCase(12,3, Result=4)]
    [TestCase(12,2, Result=6)]
    [TestCase(12,4, Result=3)]
    public int DivideTest(int n, int d)
    {
      return( n / d );
    }
