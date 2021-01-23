    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Learn.MVVM.Example.Models.Business;
     
    namespace Learn.MVVM.Example.Models
    {
        public class PersonModel
        {
            #region Constructors
     
            public PersonModel()
            {
     
            }
     
            #endregion Constructors)
     
            #region Methods
     
            public List<Person> GetPersons()
            {
                return new List<Person>
                {
                    new Person("Алексей", "Алексеевич", "Алексеев", new DateTime(1980, 5, 10), Gender.Male),
                    new Person("Петр", "Петрович", "Петров", new DateTime(1977, 9, 21), Gender.Male),
                    new Person("Виктория", "Викторовна", "Викторова", new DateTime(1991, 1, 7), Gender.Female)
                };
            }
     
            #endregion Methods
     
        }
    }
