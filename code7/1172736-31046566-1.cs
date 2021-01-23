    public class PersonViewModel
    {
         public PersonViewModel()
         {
              Persons = new List<Person>();
         }
    
         public int PersonId { get; set; }
    
         public List<Person> Persons { get; set; }
    }
