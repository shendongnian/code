     protected override void Seed(ConsoleApplication3.YourContext context)
     {
            var languages = new[]
            {
                new Language {Id = 1, Name = "Portuguese"},
                new Language {Id = 2, Name = "English"},
                new Language {Id = 3, Name = "Spanish"},
                new Language {Id = 4, Name = "French"},
            };
            
            // This way you can add all the languages even when there is not associated to a product
            // If you change the Name property, then all the entity properties will be updated
            context.Languages.AddOrUpdate(l => l.Name, languages);
            var products = new[]
            {
                new Product {Id = 1, Name = "NameProduct1", Languages = new List<Language> {languages[0],languages[1],languages[3]}},
                new Product {Id = 2, Name = "NameProduct2", Languages = new List<Language> {languages[0]}},
            };
            context.Products.AddOrUpdate(p=>p.Name,products);
            context.SaveChanges();
    }
