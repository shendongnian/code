    Person[] p2 = p1
                .Where(c => string.IsNullOrEmpty(c.Error))
                .Select(
                    c => new Person { Name = c.Name, Age = c.Age }
                 )
                .Union(
                p1.Where(d => !string.IsNullOrEmpty(d.Error))
                .Select(
                    d => new Person { Error = d.Error }
                 )
                 ).ToArray();
