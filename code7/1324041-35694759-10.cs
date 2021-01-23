    public class Test
    {
        [Fact]
        public void FactMethodName()
        {
            var fooFileCode = new FileCode("foo");
            var barFileCode = new FileCode("bar");
            var kernel = new StandardKernel();
            kernel
                .Bind<IFileProcessorFactory>()
                .To<FileProcessorFactory>();
            kernel
                .Bind<IThing>()
                .To<ThingFoo>()
                .WhenFileCode(fooFileCode);
            kernel
                .Bind<IThing>()
                .To<ThingBar>()
                .WhenFileCode(barFileCode);
            kernel
                .Bind<IOtherThing>()
                .To<OtherThingFoo>()
                .WhenFileCode(fooFileCode);
            kernel
                .Bind<IOtherThing>()
                .To<OtherThingBar>()
                .WhenFileCode(barFileCode);
            var fileProcessor = kernel.Get<IFileProcessorFactory>().Create(barFileCode);
            fileProcessor.Thing.Should().BeOfType<ThingBar>();
            fileProcessor.Thing.FileCode.Should().Be(barFileCode);
            fileProcessor.OtherThingWrapper.OtherThing.Should().BeOfType<OtherThingBar>();
            fileProcessor.OtherThingWrapper.OtherThing.FileCode.Should().Be(barFileCode);
        }
    }
    public static class BindingExtensionsForFileCodes
    {
        public static IBindingInNamedWithOrOnSyntax<T> WhenFileCode<T>(
            this IBindingWhenSyntax<T> syntax,
            FileCode fileCode)
        {
            return syntax.When(req => req
                .Parameters
                .OfType<FileCodeParameter>()
                .Single()
                .FileCode.Value == fileCode.Value);
        }
    }
