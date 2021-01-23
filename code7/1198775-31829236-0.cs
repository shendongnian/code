            List<Lookup> current = new List<Lookup>();
            List<Lookup> history = new List<Lookup>();
            List<Lookup> changes= new List<Lookup>();
            current.Add(new Lookup() { Id = 1, Name = "sdf", Price = 20 });
            current.Add(new Lookup() { Id = 2, Name = "asdf", Price = 30 });
            current.Add(new Lookup() { Id = 3, Name = "bsdf", Price = 40 });
            history.Add(new Lookup() { Id = 1, Name = "sdf", Price = 10 });
            history.Add(new Lookup() { Id = 2, Name = "asdf", Price = 30 });
            history.Add(new Lookup() { Id = 3, Name = "bsdf", Price = 10 });
            changes = (from cur in current join his in history on 
                      cur.Id equals his.Id where cur.Price != his.Price select 
                      new Lookup() { Id = his.Id, Name = his.Name, Price = his.Price }).
                      ToList();
