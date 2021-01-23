    public class Person
      {
        private string firstName;
        private string lastName;  
        ...
      }
            
    ...
    Dictionary<string, Person> dictPersons = new Dictionary<string, Person>();
    // statements to populate the dictionary with keys and a Person objects.
    ....
    foreach(var personEntry in dictPersons.ORderBy(p => p.Value.lastName).ThenBy(p => p.Value.firstName)
      {
      ...
      // When you use the firtName or lastName properties,just refer to it as:
      Console.WriteLine("LastName: {0}  FirstName: {1}", personEntry.Value.lastName, personEntry.Value.firstName);
      ...
    }
