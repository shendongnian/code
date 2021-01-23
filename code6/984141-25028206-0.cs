    public interface IPerson
    {
        IPerson WithName(string name);
        IPerson WithAge(int age);
    }
    
    public class Person : IPerson
    {
        //You can also add required parameters here.  That'll 
        //ensure that a person is not saved before his specifications
        //are atleast minimally specified.
        public Person() { }
    }
    
    new Person().WithAge(18).WithName("Steven").Save();
