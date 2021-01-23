    using FluentAssertions;
    using Ninject;
    using Xunit;
    namespace NinjectTest.SO38013150
    {
        public class Test
        {
            [Fact]
            public void Foo()
            {
                var kernel = new StandardKernel();
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
                kernel.Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>();
                var factory = kernel.Get<IUnitOfWorkFactory>();
            
                var unitOfWork1 = factory.Create();
                var unitOfWork2 = factory.Create();
                unitOfWork1.Should().NotBeSameAs(unitOfWork2);
            }
        }
    }
