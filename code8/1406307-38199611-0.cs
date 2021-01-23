    [Test]
    public void Test()
    {
        var person = Substitute.For<Person>();
        person.GetAge().Returns(20);
        var age = person.GetAge(); //returns 20
        var name = person.GetName(); //returns empty string
 
        var partialPerson = Substitute.ForPartsOf<Person>();
        partialPerson.GetAge().Returns(20);
        var age2 = partialPerson.GetAge(); //returns 20
        var name2 = partialPerson.GetName(); //returns John
    }
 
    public class Person
    {
        public string Name { get; } = "John";
        public int Age { get; } = 10;
 
        public virtual int GetAge()
        {
            return Age;
        }
 
        public virtual string GetName()
        {
            return Name;
        }
    }
