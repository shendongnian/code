    using FluentAssertions;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Xunit;
    public class MenuItemCommandConventionTest
    {
        [Fact]
        public void Test()
        {
            var kernel = new StandardKernel();
            kernel.Bind(x => x
                .FromThisAssembly()
                .IncludingNonePublicTypes()
                .SelectAllClasses()
                .InheritedFrom<ICommand>()
                .BindWith<CommandBindingGenerator>());
            kernel.Get<AboutMenuItem>()
                  .Command.Should().BeOfType<AboutCommand>();
            kernel.Get<OptionsMenuItem>()
                  .Command.Should().BeOfType<OptionsCommand>();
        }
    }
