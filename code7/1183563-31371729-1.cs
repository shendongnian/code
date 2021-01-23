    List<MyData> lst = new List<MyData>();
    lst.Add(new MyData()
            {
                Longitud = 1,
                Tipo = "123",
                Nombre = "n1"
            });
            lst.Add(new MyData()
            {
                Longitud = 1,
                Tipo = "456",
                Nombre = "n1"
            });
            var cloned = lst.ToList();
            Dictionary<MyData, Tuple<string, string, int>> originalValues = new Dictionary<MyData, Tuple<string, string, int>>();
            foreach (var item in cloned)
                originalValues[item] = new Tuple<string, string, int>(item.Nombre, item.Tipo, item.Longitud);
            cloned.Remove(lst[0]);
            cloned.Add(new MyData()
            {
                Longitud = 2,
                Nombre = "aaaaaa",
                Tipo = "gggg"
            });
            var added = (from p in cloned
                         join orig in lst
                             on p equals orig into left
                         from orig in left.DefaultIfEmpty()
                         where orig == null
                         select p).ToList();
            var deleted = (from orig in lst
                           join c in cloned
                               on orig equals c into left
                           from c in left.DefaultIfEmpty()
                           where c == null
                           select orig).ToList ();
            var changed = (from orig in lst
                           join c in cloned
                               on orig equals c
                           where originalValues[orig].Item1 != orig.Nombre ||
                               originalValues[orig].Item2 != orig.Tipo ||
                               originalValues[orig].Item3 != orig.Longitud
                           select orig
                                ).ToList();
