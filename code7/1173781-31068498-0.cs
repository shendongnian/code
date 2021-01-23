    List<YourClass> objects = new List<YourClass>();
    String[] lines = File.ReadAllLines("path\to\file.txt");
    foreach (string line in lines)
    {
        try
        {
            var obj = JsonDeserialize<YourClass>(line);
            objects.Add(obj);
        }
        catch (Exception) { }
    }
