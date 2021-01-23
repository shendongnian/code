    using System.Collections.Generic;
    using System.Linq;
    using Core1RtmEmptyTest.Entities;
    using Microsoft.Extensions.DependencyInjection;
    
    namespace Core1RtmEmptyTest.Migrations
    {
        public static class ApplicationDbContextSeedData
        {
            public static void SeedData(this IServiceScopeFactory scopeFactory)
            {
                using (var serviceScope = scopeFactory.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                    if (!context.Persons.Any())
                    {
                        var persons = new List<Person>
                        {
                            new Person
                            {
                                FirstName = "Admin",
                                LastName = "User"
                            }
                        };
                        context.AddRange(persons);
                        context.SaveChanges();
                    }
                }
    
            }
        }
    }
