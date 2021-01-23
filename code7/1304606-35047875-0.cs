    DirectoryInfo dir = new DirectoryInfo("C:/Users/Wiz/Desktop/folder/");
    foreach (var item in dir.GetDirectories())
    {
        item.MoveTo(Path.Combine(item.Parent.FullName, "a" + item.Name));
        Console.WriteLine("a" + item.Name);
     }
     Console.ReadLine();
