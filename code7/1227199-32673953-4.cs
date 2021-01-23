    namespace Aquapark.ViewModels
    {    
         
        public class OpinionViewModel
        {
          public class OpinionDTO()
          {
             public string Content {get; set;}
             public DateTime Date {get; set;}
             public string PersonId {get; set;}
          }
          public class PersonDTO()
          {
             public int PersonId { get; set; }       
             public long Pesel { get; set; }       
             public string FirstName { get; set; }    
             public string LastName { get; set; }     
             public DateTime DateOfBirth  { get; set; }
             public string FullName
              {
                get
                 {
                   return FirstName + " " + LastName;
                 }
              }
          }
            public IEnumerable<OpinionDTO> Opinions { get; set; }
            public IEnumerable<PersonDTO> Authors { get; set; }
        }
    }
