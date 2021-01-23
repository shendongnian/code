    [Test]
    [TestCase(37, Result = 0)]
    [TestCase(36, Result = 24)]
    [TestCase(35, Result = 24)]
    [TestCase(30, Result = 16)]
    [TestCase(29, Result = 16)]
    [TestCase(26, Result = 16)]
    [TestCase(22, Result = 12)]
    [TestCase(12, Result = 8)]
    [TestCase(11, Result = 0)]
    [TestCase(10, Result = 0)]
    public int GetNumberOfSlices(int diameter)
    {
        var pizzas = new[] {
            new[] { 11, 0 }, 
            new[] { 20, 8 }, 
            new[] { 24, 12 }, 
            new[] { 30, 16 }, 
            new[] { 36, 24 }
        };
        var pizza = pizzas.FirstOrDefault(p => diameter <= p[0]);
        return pizza == null ? 0 : pizza[1];
    }
