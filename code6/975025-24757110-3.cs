    public class PersonMapping : ClassMapping<Person>
    {
      public PersonMapping()
      {
         Id(x=>x.Id);
         Property(x=>x.Name);
         //Property(x=>x.Gender);
         ManyToOne(x => x.Gender, x =>
            {
                x.PropertyRef("ShortName"); // this is the property of a Gender class!
                x.Column("Gender");    // to be mapped with the Pesons's column Gender
            });
      }
    }
