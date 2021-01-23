            List<Table> table = new List<Table>();
            table.Add(new Table { Name = "Jhon", id = "4", work = "clear" });
            table.Add(new Table { Name = "Jhon", id = "10", work = "load" });
            table.Add(new Table { Name = "Jhon", id = "5", work = "convert" });
            table.Add(new Table { Name = "Nick", id = "2", work = "load" });
            table.Add(new Table { Name = "Nick", id = "7", work = "load" });
            table.Add(new Table { Name = "Nick", id = "9", work = "load" });
            var employee =  table.GroupBy(t => t.Name)
                .Select(g => new Empoloyee() {Name = g.Key, components = g.Select(t => new Component {id = t.id, work = t.work} ).ToList()})
                .ToList();
 
