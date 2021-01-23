    protected override void Seed(WebApplication2.Models.ApplicationDbContext context) {
    
        if (!context.Persons.Any())
        {   
            var persons = new List<Person> { 
                new Person{FirstName = "John", LastName = "Doe", CellNumber = "123-456-789", SecondaryPhoneNumber = "98873213", Address = "1street 2",BirthDate = DateTime.Now.Date, Pesel = "312312312", Notes = "Annoying"},
                new Person{FirstName = "Anna", LastName = "Doe", CellNumber = "113-456-789", SecondaryPhoneNumber = "98873213", Address = "1street 2",BirthDate = DateTime.Now.Date, Pesel = "548555672", Notes = "Less Annoying"}
            };
    
            persons.ForEach(person => context.Persons.Add(person));
            context.SaveChanges();
        }
    
        if (!context.Meetings.Any())
        {
            var meetings = new List<Meeting>{
                new Meeting{PersonId = 1, Body = "Body of meeting", Date = DateTime.Now}
            };
    
            meetings.ForEach(meeting => context.Meetings.Add(meeting));
            context.SaveChanges();
        }
        
        if (!context.Statuses.Any())
        {
            var statuses = new List<Status> {
                new Status{Name = "OK"},
                new Status {Name = "NOT_OK"}
            };
    
            statuses.ForEach(status => context.Statuses.Add(status));
            context.SaveChanges();
        }
    
    }
