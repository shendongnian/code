    public void Test()
    {
        Person person = null;
        using (var ctx = new MainContext())
        {
            person = ctx.Persons
                .Include(c => c.Profile);
                .FirstOrDefault(p => p.Name == "Ben");
                // code inside the using
                var profile = person.Profile;
            }
        }
    }
