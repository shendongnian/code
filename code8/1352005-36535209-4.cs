        protected override void Seed(EF.MyDbContext context)
        {
            var person1 = new Person {Id= 1, FirstName = "Andrew", Surname = "Peters" };
            var person2 = new Person {Id= 2, FirstName = "Brice", Surname = "Lambson" };
            var person3 = new Person {Id= 3, FirstName = "Rowan", Surname = "Miller" };
            context.People.AddOrUpdate(p => p.Id, person1, person2, person3);
            var user1 = new User { Id = 1, LoginName = "Andrew", Password = "Peters" };
            var user3 = new User { Id = 3, LoginName = "Rowan", Password = "Miller" };
            context.Users.AddOrUpdate(p => p.Id, user1, user3);
        }
