    public class PersonMap : ClassMap<Person>
    { 
        public PersonMap() 
        {
            Table("Person");
            Id(p => p.Id, "Id").GeneratedBy.Native().Not.Nullable();
            Map(p => p.Name, "Name").Length(255).Not.Nullable();
    
            Component(p => p.Dog, d =>
            {
                d.Map(dog => dog.Name, "DogName").Not.Nullable();
                d.Map(dog => dog.Age, "DogAge").Not.Nullable();
            }
        }    
    }
