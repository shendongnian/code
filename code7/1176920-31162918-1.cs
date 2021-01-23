            Model6Context context = new Model6Context(connection);
            User user = new User
            {
                Firstname = "Bubi",
                Address = new Address
                {
                    City = "Modena"
                }
            };
            context.Users.Add(user);
            context.SaveChanges();
            int userId = user.Id;
            context.Dispose();
            context = new Model6Context(connection);
            user = context.Users.First(u => u.Id == userId);
            Console.WriteLine("{0} {1}", user.Firstname, user.Address.City);
            user.Address.City = "Bologna";
            context.SaveChanges();
            context.Dispose();
            context = new Model6Context(connection);
            user = context.Users.First(u => u.Id == userId);
            Console.WriteLine("{0} {1}", user.Firstname, user.Address.City);
