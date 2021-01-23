    public static void RemoveLine(string line)
    {
         var document = File.ReadAllLines("...").ToList();
         document.Remove(line);
         document.WriteAllLines("..");
    }
