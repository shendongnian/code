    class Person {}
    class SpecialPerson : Person {}
    
    var list = new List<Person>();
    // this resolves to the generic version
    list.RemoveWhere(e => e.Name.Contains("Peter");
    // this gives ambiguous call compiler error
    list.RemoveWhere(e => e is SpecialPerson);
    // if I help the compiler it resolves correctly
    list.RemoveWhere<Person>(e => e is SpecialPerson);
