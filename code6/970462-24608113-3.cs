       public interface IRepo
       {
          string Foo();
          string Bar();
       }
    
       public class RealRepo : IRepo
       {
          public RealRepo(string p1, string p2) {Console.WriteLine("CTOR : {0} {1}", p1, p2); }
          // ** These need to be virtual in order for the partial mock Setups
          public virtual string Foo() { return "RealFoo"; }
          public virtual string Bar() {return "RealBar"; }
       }
    
       public class Sut
       {
          private readonly IRepo _repo;
          public Sut(IRepo repo) { _repo = repo; }
    
          public void DoFooBar()
          {
             Console.WriteLine(_repo.Foo());
             Console.WriteLine(_repo.Bar());
          }
       }
    
    
       [TestFixture]
       public class SomeFixture
       {
          [Test]
          public void SomeTest()
          {
            var mockRepo = new Mock<RealRepo>("1st Param", "2nd Param");
            // For the partially mocked methods
            mockRepo.Setup(mr => mr.Foo())
               .Returns("MockedFoo");
            // To wireup the concrete class.
            mockRepo.CallBase = true;
            var sut = new Sut(mockRepo.Object);
            sut.DoFooBar();
          }
       }
