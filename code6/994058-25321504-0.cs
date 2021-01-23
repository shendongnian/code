    public interface IBar { }
    public class Bar : IBar { }
    public interface IFoo { }
    class Foo1 : IFoo
    {
        public Foo1(IBar bar) { }
    }
    class Foo2 : IFoo
    {
        public Foo2(IBar bar, bool theParametersName) { }
    }
        [Fact]
        public void FactMethodName()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IBar>().To<Bar>();
            kernel.Bind<IFoo>().To<Foo1>();
            kernel.Bind<IFoo>().To<Foo2>().WithConstructorArgument("theParametersName", true);
            kernel.Bind<IFoo>().To<Foo2>().WithConstructorArgument("theParametersName", false);
            List<IFoo> foos = kernel.GetAll<IFoo>().ToList();
            foos.Should().HaveCount(3);
        } 
