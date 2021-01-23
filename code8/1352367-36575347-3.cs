    public class Generic2DArrayAssertions<T> 
    {
        T[,] _actual;
        public Generic2DArrayAssertions(T[,] actual)
        {
            _actual = actual;
        }
        public bool Equal(T[,] expected, Func<T,T, bool> func)
        {
            for (int i = 0; i < expected.Rank; i++)
                _actual.GetUpperBound(i).Should().Be(expected.GetUpperBound(i), 
                                                     "dimensions should match");
            for (int x = expected.GetLowerBound(0); x <= expected.GetUpperBound(0); x++)
            {
                for (int y = expected.GetLowerBound(1); y <= expected.GetUpperBound(1); y++)
                {
                    func(_actual[x, y], expected[x, y])
                         .Should()
                         .BeTrue("'{2}' should equal '{3}' at element [{0},{1}]",
                          x, y, _actual[x,y], expected[x,y]);
                }
            }
            return true;
        }
    }
