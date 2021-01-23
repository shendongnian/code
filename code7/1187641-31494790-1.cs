            var usersL = new List<User>()
                            {
                                new User{ID = 1,Email = "abc@foo.com"},
                                new User{ID = 2,Email = "def@foo.com"}
                            };
            var usersR = new List<User>()
                            {
                                new User{ID = 1,Email = "abc@foo.com"},
                                new User{ID = 2,Email = "def@foo.com"}
                            };
            var both = (from l in usersL select l)
                .Intersect(from users in usersR select users);
            foreach (var r in both)
                Console.WriteLine(r.Email);
