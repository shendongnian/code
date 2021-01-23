    [TestMethod]
    public void CurrentAndPrevious()
    {
        var input = new int[] { 1, 2, 3, 4, 5 };
        var output = Enumerable.Repeat(0,1)   // an initial zero value
             .Concat(input)                   // followed by the list
                                              // zipped with the list
             .Zip(input, (x, y) => new {current = y, previous = x});
        // a test that passes (using FluentAssertions syntax)
        string.Join(",", output.Select(x => $"({x.current},{x.previous})"))
           .Should().Be("(1,0),(2,1),(3,2),(4,3),(5,4)");
    }
