    public class Name
    {
           private string firstName;
           private string lastName;
           public Name(String firstName, String lastName)
           {
                 this.firstName = firstName;
                 this.lastName  = lastName;
           }
           public string FirstName { get { return this.firstName; } }
           public string LastName  { get { return this.lastName; } }
     }
     class Program
     {
           static void Main(String[] args)
           {
               Name myName = new Name("John", "Richard");
               Console.WriteLine(myName.FirstName);
               Console.WriteLine(myName.LastName);
           }
     }
