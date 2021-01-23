    static List<T> ReadFromCsv<T>(string data)
    {
        var objs = new List<T>();
        var rows = data.Split(new[] {"\r\n"}, StringSplitOptions.None);
        //create index, header dict
        var headers = rows[0].Split(',').Select((value, index) => new {value, index})
            .ToDictionary(pair => pair.index, pair => pair.value);
        //get properties to find and cache them for the moment
        var propertiesToFind = typeof (T).GetProperties().Where(x => x.GetCustomAttributes<ReadFromCsvAttribute>().Any());
        //create index, propertyinfo dict
        var indexToPropertyDict =
            headers.Where(kv => propertiesToFind.Select(x => x.Name).Contains(kv.Value))
                .ToDictionary(x => x.Key, x => propertiesToFind.Single(p => p.Name == x.Value));
        foreach (var row in rows.Skip(1))
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            var cells = row.Split(',');
            for (int i = 0; i < cells.Length; i++)
            {
                if (indexToPropertyDict.ContainsKey(i))
                {
                    //set data
                    indexToPropertyDict[i].SetValue(obj, cells[i]);
                }
            }
            objs.Add(obj);
        }
        return objs;
    }
