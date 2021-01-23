    using FluentAssertions;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Extensions.Conventions.BindingGenerators;
    using Ninject.Syntax;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit;
    namespace NinjectTest.SO36424126
    {
        public interface IPerson
        {
            string SomeValue { get; set; }
        }
        class BarPerson : IPerson
        {
            public string SomeValue { get; set; }
        }
        class FooPerson : IPerson
        {
            public string SomeValue { get; set; }
        }
        public interface IProfileService
        {
            T PopulateProfile<T>() 
                where T : IPerson, new();
        }
        internal class ProfileService : IProfileService
        {
            public T PopulateProfile<T>()
                where T : IPerson, new()
            {
                var personProfile = Activator.CreateInstance<T>();
                personProfile.SomeValue = "initialized";
                return personProfile;
            }
        }
        internal class PersonBindingGenerator : IBindingGenerator
        {
            private static readonly MethodInfo PopulateOpenGenericMethodInfo = typeof(IProfileService).GetMethod("PopulateProfile");
            public IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>> CreateBindings(Type type, IBindingRoot bindingRoot)
            {
                yield return bindingRoot
                    .Bind(type)
                    .ToMethod(x => CreatePerson(x.Kernel.Get<IProfileService>(), type));
            }
            private static object CreatePerson(IProfileService profileService, Type type)
            {
                var closedGeneric = PopulateOpenGenericMethodInfo.MakeGenericMethod(type);
                return closedGeneric.Invoke(profileService, new object[0]);
            }
        }
        public class Test
        {
            [Fact]
            public void Foo()
            {
                var kernel = new StandardKernel();
                kernel.Bind<IProfileService>().To<ProfileService>();
                kernel.Bind(s => s
                    .FromThisAssembly()
                    .IncludingNonePublicTypes()
                    .SelectAllClasses()
                    .InheritedFrom<IPerson>()
                    .BindWith<PersonBindingGenerator>());
                kernel.Get<BarPerson>().SomeValue.Should().Be("initialized");
            }
        }
    }
