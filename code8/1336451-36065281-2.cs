    public interface INameable 
    {
        string Name { get; }
    }
    public class Person : INameable
    {
        public Person(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
    public class Star : INameable
    {
        public Star(string name, int brightness)
        {
             Name = name;
             Brightness = brightness;
        }
        public int Brightness { get; private set; }
        public string Name { get; private set; }
  
    }
    public void MyMethod() 
    {
        List<Person> people = new List<Person> { new Person("Sam"), new Person("Pop") };
        // note: I *cannot* do the following, but let's pretend I can
        IList<INameable> nameables = people;
        // note: nameables and people technically reference the same object
        // so consider what happens when I do this:
        nameables.Add(new Star("Alpha Centauri", 9000));
        // nameables is cool, but oh man, my people list is now totally messed up. Sabotage!
        // Thanks goodness for covariance in generics!
    }
