        public interface IFoo
        {
            void Bar(ref StringBuilder err, out string val1, out string val2);
        }
        public class Foo : IFoo
        {
            public void Bar(ref StringBuilder err, out string val1, out string val2)
            {
                val1 = "Hello";
                val2 = "Howdy";
            }
        }
        public class ClassToBeTested
        {
            private IFoo _foo;
            public StringBuilder Errors = new StringBuilder();
            public ClassToBeTested(IFoo foo)
            {
                _foo = foo;
            }
            public string MethodToBeTested()
            {
                string val1, val2;
                _foo.Bar(ref Errors, out val1, out val2);
                return val1 + " " + val2;
            }
        }
        [Fact]
        public void MethodUsedForTesting()
        {
            var foo = new Mock<IFoo>();
            var sut = new ClassToBeTested(foo.Object);
            var val1 = "Hi";
            var val2 = "Hey";
           
            // the setup for a ref has to be the same object instance 
            // that is used by MethodToBeTested() ...
            // there isn't currently It.Any support for ref parameters
            foo.Setup(x => x.Bar(ref sut.Errors, out val1, out val2));
            string expected = "Hi Hey";
            string actual = sut.MethodToBeTested();
            Assert.Equal(expected, actual); // this test passes
        }
