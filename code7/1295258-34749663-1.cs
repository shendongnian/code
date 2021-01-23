    public static void RemoveLine(string line)
    {
         var document = File.ReadAllLines("...");
         document.Remove(line);
         document.WriteAllLines("..");
    }
