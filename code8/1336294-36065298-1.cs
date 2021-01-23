    using System;
    using System.Linq;
    using FluentAssertions;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Xunit;
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class KeyAttribute : Attribute
    {
        public KeyAttribute(string key)
        {
            Key = key;
        }
        public string Key { get; private set; }
    }
    public interface IInterface { }
    [Key("key1")]
    public class Impl1 : IInterface { }
    [Key("key2")]
    public class Impl2 : IInterface { }
    public class Test
    {
        [Fact]
        public void Foo()
        {
            var kernel = new StandardKernel();
            kernel.Bind(x => x
                .FromThisAssembly()
                .SelectAllClasses()
                .InheritedFrom<IInterface>()
                .BindAllInterfaces()
                .Configure((syntax, type) => syntax.Named(GetKeyFrom(type))));
            kernel.Get<IInterface>("key1").Should().BeOfType<Impl1>();
            kernel.Get<IInterface>("key2").Should().BeOfType<Impl2>();
        }
        private static string GetKeyFrom(Type type)
        {
            return type
                .GetCustomAttributes(typeof(KeyAttribute), false)
                .OfType<KeyAttribute>()
                .Single()
                .Key;
        }
    }
