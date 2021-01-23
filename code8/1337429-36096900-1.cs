    List<string> list = new List<string>();
    list.Add("aaa");
    list.Add("bbb");
    
    FileSystem.SerializeToFile(list, @"d:\test.txt");
    List<string> anotherList = FileSystem.OpenSerialized<List<string>>(@"d:\test.txt");
