    protected override void Seed(Domain.Context.DocumentationContext context)
    {
                         
           var professors = new List<Professor>
           {
             new Professor
             {
                Id = 1,
                Name = "Arturo Anand",
                EnrollmentDate = DateTime.Parse("09-08-2015"),
                Presentation = new List<Presentation>
                  {
                     new Presentation
                     {
                     PresentationTitle = "Test",
                     PresentationTime = DateTime.Parse("09-09-2015"),
                     Level = Level.Advanced,
                     }
                  }
             }
         };
      //make sure to specify a key for the AddOrUpdate Method to ensure 
      //that you don’t create duplicates when you seed data during development.
       professors.ForEach(prof => context.Professors.AddOrUpdate(x => x.Id, prof));
    }
