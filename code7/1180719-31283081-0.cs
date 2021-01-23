            public class Foo
            {
                private readonly Bar _bar;
                public Foo(Bar bar)
                {
                    _bar = bar;
                }
                public void DoSomething()
                {
                    _bar.DoSomethingElse();
                }
            }
            public interface Bar
            {
                void DoSomethingElse();
            }
            public class AnImplementationOfBar : Bar
            {
                public void DoSomethingElse()
                {
                    throw new System.NotImplementedException();
                }
            }
            [Test]
            public void Foo_interacts_correctly_with_its_bar()
            {
                var fakeBar = Substitute.For<Bar>();
                var foo = new Foo(fakeBar);
                foo.DoSomething();
                fakeBar.Received().DoSomethingElse(); //This is the assertion of the test and verifies whether fakeBar.DoSomethingElse has been called.
            }
            public static void Main(string[] args)
            {
                //Production code would look like this:
                var foo = new Foo(new AnImplementationOfBar());
                //next line throws because AnImplementationOfBar.DoSomethingElse has not been implemented yet
                foo.DoSomething();
            }
