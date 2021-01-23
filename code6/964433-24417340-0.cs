    using Antlr4.StringTemplate;
    
    Person person = new Person() ;
    person.Name = "John" ;
    person.Street = "123 Main St" ;
    person.City   = "Anytown" ;
    person.Zip    = 12345 ;
    Template hello = new Template("Hello. My name is <p.Name>. My Address is <p.Street>, <p.City>,  <p.State> <p.Zip>.");
    hello.Add("p", person);
    Console.Out.WriteLine(hello.Render());
