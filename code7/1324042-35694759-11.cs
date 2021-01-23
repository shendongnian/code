    using FluentAssertions;
    using Ninject;
    using Ninject.Activation;
    using Ninject.Parameters;
    using Ninject.Planning.Targets;
    using Ninject.Syntax;
    using System.Linq;
    using Xunit;
    namespace NinjectTest.ParameterContextual
    {
        public class FileCode
        {
            public FileCode(string value)
            {
                Value = value;
            }
            public string Value { get; private set; }
        }
        public interface IThing
        {
            FileCode FileCode { get; }
        }
        public abstract class Thing : IThing
        {
            protected Thing(FileCode fileCode)
            {
                FileCode = fileCode;
            }
            public FileCode FileCode { get; private set; }
        }
        public class ThingFoo : Thing
        {
            public ThingFoo(FileCode fileCode) : base(fileCode) { }
        }
        public class ThingBar : Thing
        {
            public ThingBar(FileCode fileCode) : base(fileCode) { }
        }
        public interface IOtherThing
        {
            FileCode FileCode { get; }
        }
        public abstract class OtherThing : IOtherThing
        {
            protected OtherThing(FileCode fileCode)
            {
                FileCode = fileCode;
            }
            public FileCode FileCode { get; private set; }
        }
        public class OtherThingFoo : OtherThing
        {
            public OtherThingFoo(FileCode fileCode) : base(fileCode) { }
        }
        public class OtherThingBar : OtherThing
        {
            public OtherThingBar(FileCode fileCode) : base(fileCode) { }
        }
        public class OtherThingWrapper
        {
            public OtherThingWrapper(IOtherThing otherThing)
            {
                OtherThing = otherThing;
            }
            public IOtherThing OtherThing { get; private set; }
        }
        public class FileProcessor
        {
            public FileProcessor(IThing thing, OtherThingWrapper otherThingWrapper)
            {
                Thing = thing;
                OtherThingWrapper = otherThingWrapper;
            }
            public IThing Thing { get; private set; }
            public OtherThingWrapper OtherThingWrapper { get; private set; }
        }
        public interface IFileProcessorFactory
        {
            FileProcessor Create(FileCode fileCode);
        }
        internal class FileProcessorFactory : IFileProcessorFactory
        {
            private readonly IResolutionRoot resolutionRoot;
            public FileProcessorFactory(IResolutionRoot resolutionRoot)
            {
                this.resolutionRoot = resolutionRoot;
            }
            public FileProcessor Create(FileCode fileCode)
            {
                return this.resolutionRoot.Get<FileProcessor>(new FileCodeParameter(fileCode));
            }
        }
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
        internal class FileCodeParameter : IConstructorArgument
        {
            private readonly FileCode fileCode;
            public FileCodeParameter(FileCode fileCode)
            {
                this.fileCode = fileCode;
            }
            public string Name { get { return "File Code Parameter"; } }
            public bool ShouldInherit { get { return true; } }
            public FileCode FileCode  { get { return this.fileCode; } }
            public bool Equals(IParameter other)
            {
                var otherFileCodeParameter = other as FileCodeParameter;
                if (otherFileCodeParameter == null)
                {
                    return false;
                }
                return otherFileCodeParameter.fileCode == this.fileCode;
            }
            public object GetValue(IContext context, ITarget target)
            {
                return this.fileCode;
            }
            public bool AppliesToTarget(IContext context, ITarget target)
            {
                return target.Type == typeof(FileCode);
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
    }
