    public class PersonMapper : ClassMapper<Person>
    {
        public PersonMapper()
        {
            Map(x => x.Address).Ignore();
            AutoMap();
        }
    }
