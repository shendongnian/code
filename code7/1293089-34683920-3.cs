    public interface IFoo {
       public bool DoSomething(string);
       public bool TryParse(string, out string));
    }
    
    /* 1 */ var mock = new Mock<IFoo>();
    /* 2 */ mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
