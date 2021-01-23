    using System;
    using FluentAssertions;
    using Ninject;
    using Ninject.Modules;
    using Xunit;
    namespace NinjectTest.SingletonBoundToMultipleTypes
    {
        interface IPersonalityProvider
        {
            void BeHappy();
        }
        class PersonalityConfiguration : IPersonalityProvider
        {
            private int m_personalityScale = 0;
            public PersonalityConfiguration()
            {
                m_personalityScale = 0;
            }
            public void BeHappy()
            {
                throw new NotImplementedException();
            }
        }
        class Person
        {
            public Person(IPersonalityProvider personality)
            {
                Personality = personality;
            }
            public IPersonalityProvider Personality { get; set; }
        }
        class ProgramNinjectModule : NinjectModule
        {
            public override void Load()
            {
                Bind<IPersonalityProvider, PersonalityConfiguration>()
                    .To<PersonalityConfiguration>()
                    .InSingletonScope();
            }
        }
        public class Test
        {
            [Fact]
            public void PerformTest()
            {
                using (var nKernel = new StandardKernel(new ProgramNinjectModule()))
                {
                    //Singleton works here
                    PersonalityConfiguration crazy1 = nKernel.Get<PersonalityConfiguration>();
                    PersonalityConfiguration crazy2 = nKernel.Get<PersonalityConfiguration>();
                    ReferenceEquals(crazy1, crazy2).Should().BeTrue();
                    //Expecting PersonalityConfig Singleton to bind to Person1 and 2, does not
                    Person person1 = nKernel.Get<Person>();
                    Person person2 = nKernel.Get<Person>();
                    ReferenceEquals(person1.Personality, person2.Personality)
                        .Should().BeTrue();
                    //Obviously this works
                    Person person3 = new Person(crazy1);
                    Person person4 = new Person(crazy1);
                    ReferenceEquals(person3.Personality, person4.Personality)
                        .Should().BeTrue();
                }
            }
        }
    }
