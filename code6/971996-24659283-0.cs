    public class Thing
    {
        public string Name { get; set; }
    }
    public class AnotherClass
    {
        public virtual void Process(Thing thing)
        {
        }
    }
    public class CreateThingFactory
    {
        private readonly AnotherClass _anotherClass;
        public CreateThingFactory(AnotherClass anotherClass)
        {
            _anotherClass = anotherClass;
        }
        public void CreateThing()
        {
            var thing = new Thing();
            thing.Name = "Name";
            _anotherClass.Process(thing);
        }
    }
    public class CreateThingFactoryTests
    {
        [Fact]
        public void CreateThingTest()
        {
            // arrange
            var anotherClass = Substitute.For<AnotherClass>();
            var sut = new CreateThingFactory(anotherClass);
            // act
            sut.CreateThing();
            // assert
            anotherClass.Received().Process(Arg.Is<Thing>(thing => !string.IsNullOrEmpty(thing.Name)));
        }
    }
