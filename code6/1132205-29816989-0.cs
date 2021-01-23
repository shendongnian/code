        foreach(var o in MyEntities.Stuff
                .Include(x => x.RelationalTableA)
                .Include(x => x.RelationalTableB)
                .Include(x => x.RelationalTableC)
                .ToList())
        {
            var x = new MyCustomClass();
            x.Property1 = o.RelationalTableA.PropertyX;
            x.Property2 = o.RelationalTableB.PropertyY;
            x.Property3 = o.RelationalTableC.PropertyZ;
            MyPocoList.Add(o);
        }
