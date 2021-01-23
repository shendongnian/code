            var asm = Assembly.Load("Domain.Core");
            foreach(var type in asm.GetTypes())
            {
                if(typeof(Domain.Core.Entity).IsAssignableFrom(type))
                {
                    var builder = modelBuilder.Entity(type);
                    builder.Property(typeof(string), "CreatedBy");
                    // ...
                }
            }
