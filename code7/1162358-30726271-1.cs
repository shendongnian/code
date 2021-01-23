    var list = new List<SomeClass>();
    for (var i = 0; i < 1000; i++)
    {
        list.Add(new SomeClass
        {
            Version = new Version(i, i / 2, i / 3, i / 4),
        });
    }
    var filterValue = new Version(12, 6, 4, 3);
    var filteredList = list.Filter("Version", filterValue);
    Console.WriteLine(filteredList.Single().Version);
