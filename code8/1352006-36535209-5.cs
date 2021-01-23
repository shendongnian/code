        MyDbContext ctx = new MyDbContext();
        ctx.People.ToList().ForEach(person =>
        {
            System.Console.WriteLine($"Id:{person.Id}, Name: {person.FirstName} {person.Surname}");
            if (person.User != null)
            {
                System.Console.WriteLine($"Found user, Id:{person.User.Id}, " +
                                         $"Login: {person.User.LoginName}, Password: {person.User.Password}");
             }
        });
        /*
        Output:
        Id:1, Name: Andrew Peters
        Found user, Id:1, Login: Andrew, Password: Peters
        Id:2, Name: Brice Lambson
        Id:3, Name: Rowan Miller
        Found user, Id:3, Login: Rowan, Password: Miller
        */
