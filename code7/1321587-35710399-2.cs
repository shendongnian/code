    public class Tests
    {
        [Theory, ClassData(typeof(TestCases))]
        public void AllServicesAreAvailable(
            Type[] availableServices,
            Type[] expected)
        {
            var composer = new Composer(availableServices);
            var actual = composer.GetAvailableClients(
                typeof(Plugin1), typeof(Plugin2), typeof(Plugin3));
            Assert.True(new HashSet<Type>(expected).SetEquals(actual));
        }
    }
    internal class TestCases : IEnumerable<Object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new[] { typeof(IFoo), typeof(IBar), typeof(IBaz) },
                new[] { typeof(Plugin1), typeof(Plugin2), typeof(Plugin3) }
            };
            yield return new object[] {
                new[] { typeof(IBar), typeof(IBaz) },
                new[] { typeof(Plugin2), typeof(Plugin3) }
            };
            yield return new object[] {
                new[] { typeof(IFoo), typeof(IBaz) },
                new[] { typeof(Plugin1) }
            };
            yield return new object[] {
                new[] { typeof(IFoo), typeof(IBar) },
                new[] { typeof(Plugin1), typeof(Plugin3) }
            };
            yield return new object[] {
                new[] { typeof(IFoo) },
                new[] { typeof(Plugin1) }
            };
            yield return new object[] {
                new[] { typeof(IBar) },
                new[] { typeof(Plugin3) }
            };
            yield return new object[] {
                new[] { typeof(IBaz) },
                new Type[0]
            };
            yield return new object[] {
                new Type[0],
                new Type[0]
            };
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
