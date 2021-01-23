        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    
        class PersonViewModel : Person
        {
            public string FullName { get; set; }
        }
    
        static class ConversionHelpers
        {
            public static Person ToPerson(this PersonViewModel pvm)
            {
                return new Person()
                {
                    FirstName = pvm.FirstName,
                    LastName = pvm.LastName
                };
            }
    
            public static PersonViewModel ToPersonViewModel(this Person p)
            {
                return new PersonViewModel()
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName
                };
            }
    
            public static IEnumerable<PersonViewModel> ToPersonViewModels(IEnumerable<Person> persons)
            {
                return persons.Select(p => p.ToPersonViewModel());
            }
        }
