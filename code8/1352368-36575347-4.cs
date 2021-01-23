    [TestCaseSource("differentSizedScenarios")]
    public void ShouldThrowIfDifferentSizes(float[,] actual, float[,] expected)
    {
        Assert.Throws<AssertionException>(()=>actual.Should().Equal(expected, (l, r) => l == r)).Message.Should().Be(string.Format("Expected value to be {0} because dimensions should match, but found {1}.", expected.GetUpperBound(0), actual.GetUpperBound(0)));
    }
    [TestCaseSource("missMatchedScenarios")]
    public void ShouldThrowIfMismatched(int[,] actual, int[,] expected, int actualVal, int expectedVal, string index)
    {
        Assert.Throws<AssertionException>(()=>actual.Should().Equal(expected, (l, r) => l.Equals(r))).Message.Should().Be(string.Format("Expected True because '{0}' should equal '{1}' at element [{2}], but found False.", actualVal, expectedVal, index));
    }
    [Test]
    public void ShouldPassOnMatched()
    {
        var expected = new float[,] { { 3.1f, 4.5f }, { 2, 4 } };
        var actual = new float[,] { { 3.1f, 4.5f }, { 2, 4 } };
        actual.Should().Equal(expected, (l, r) => l.Equals(r));
    }
    static object[] differentSizedScenarios = 
    {
        new object[] {
            new float[,] { { 3.1f, 4.5f }, { 2, 4 } },
            new float[,] { { 3.1f, 4.5f }, { 2, 4 }, {1,2} }
        },
        new object[] {
            new float[,] { { 3.1f, 4.5f }, { 2, 4 } },
            new float[,] { { 3.1f, 4.5f }}
        }
        // etc...
    };
    static object[] missMatchedScenarios = 
    {
        new object[] {
            new int[,] { { 1, 2}, { 3, 4 } },
            new int[,] { { 11, 2}, { 3, 4 } }
            ,1, 11, "0,0"
        },
        new object[] {
            new int[,] { { 1, 2}, { 3, 14 } },
            new int[,] { { 1, 2}, { 3, 4 } }
            ,14, 4, "1,1"
        },
        // etc...
    };
