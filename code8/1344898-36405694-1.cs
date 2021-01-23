    public class PersonMap : ClassMap<Person>
    { 
        public PersonMap() 
        {
            Table("Person");
            Id(p => p.Id, "Id").GeneratedBy.Native().Not.Nullable();
    
            References(p => p.Dog, "Dog").Nullable();
        }
    }
    
    public class DogMap : ClassMap<Dog>
    {
        Map(d => d.Id, "Id").GeneratedBy.Native();
    
        References(p => p.Person, "Person").Nullable();
        Map(d => d.Name, "Name").Not.Nullable();
        Map(d => d.Age, "Age").Not.Nullable();
        }    
    }
