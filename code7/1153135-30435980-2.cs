     List<MyClass> _Lst = new List<MyClass>();
     _Lst.Add(new MyClass { Name = "Vasya", LastName = "iakubovi4" });
     _Lst.Add(new MyClass { Name = "Vasya", LastName = "petrovi4" });
     _Lst.Add(new MyClass { Name = "Vasya", LastName = "ianukovi4" });
     _Lst.Add(new MyClass { Name = "Petya", LastName = "sergeevi4" });
     _Lst.Add(new MyClass { Name = "Igori", LastName = "alibertovi4" });
     var result = _Lst.GroupBy(m => m.Name).OrderByDescending(x => x.Count()).SelectMany(x => x).ToList();
