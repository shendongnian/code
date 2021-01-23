    abstract class AbstractFooTester {
        [Test]
        public void WhenBarIsSomethingThenResultIsSomethingElse() {
             var mockRandomNumberGenerator = createRandomNumberMock(5);
             var mockBar = Substitute.For<IBar>();
             // set up Bar
             ...
            var subject = createFoo(mockRandomNumberGenerator);
            IResult result = subject.ResolveTheProblem(bar);
            
            AssertResult(result, ...);
        }
        abstract Foo createFoo(RandomNumberGenertor g);
        RandomNumberGenertor createRandomNumberMock(Int i) { ... }
    }
    
    class TestFastFoo extends AbstractFooTester {
          Foo createFoo(RandomNumberGenertor g) { return new FastFoo(g); }
    }
    
    class TestSlowFoo extends AbstractFooTester {
          Foo createFoo(RandomNumberGenertor g) { return new SlowFoo(g); }
    }
