    [TestCase(12, 4, 3)]
    [TestCase(10, 5, 1)]
    public void DivideTest(int n, int d, int q)
    {
      Console.WriteLine("n={0}, d={1}, q={2}", n, d, q);
      Assert.AreEqual(q, n / d);
    }
