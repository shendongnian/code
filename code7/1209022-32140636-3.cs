    namespace NinjectTest.CustomFactory
    {
        using System.Linq;
        using System.Reflection;
        using FluentAssertions;
        using Ninject;
        using Ninject.Extensions.Factory;
        using Ninject.Parameters;
        using Xunit;
        public class InheritingConstructorArgumentsInstanceProvider : StandardInstanceProvider
        {
            protected override IConstructorArgument[] GetConstructorArguments(
                MethodInfo methodInfo,
                object[] arguments)
            {
                return methodInfo
                    .GetParameters()
                    .Select((parameter, index) =>
                        new ConstructorArgument(
                            parameter.Name,
                            arguments[index],
                            true))
                    .Cast<IConstructorArgument>()
                    .ToArray();
            }
        }
        public class Foo
        {
            public Bar Bar { get; private set; }
            public Foo(Bar bar)
            {
                Bar = bar;
            }
        }
        public class Bar
        {
            public string Id { get; private set; }
            public Bar(string id)
            {
                Id = id;
            }
        }
        public interface IFactory
        {
            Foo Create(string id);
        }
        public class Test
        {
            [Fact]
            public void Foo()
            {
                var kernel = new StandardKernel();
                kernel
                    .Bind<IFactory>()
                    .ToFactory(() => new InheritingConstructorArgumentsInstanceProvider());
                const string expectedId = "Hello You!";
                kernel.Get<IFactory>().Create(expectedId).Bar.Id.Should().Be(expectedId);
            }
        }
    }
