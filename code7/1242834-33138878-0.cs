    foreach (Type t in Aplicables)
    {
        filename = Path.Combine(dataDir, t.Name + "s.txt");
        var prop = typeof(DataRef<>).MakeGenericType(t).GetProperty("DataList");
        var dataList = prop.GetValue(null) as //List<int> or whatever your dataList is;
        tempJson = JsonConvert.SerializeObject(dataList.ToArray());
        System.IO.File.WriteAllText(filename, tempJson);
    }
