    public static string GetTitleCase(string fullName)
    {
        string[] names = fullName.Split(' ');
        List<string> currentNameList = new List<string>();
        foreach (var name in names)
        {
            if (Char.IsUpper(name[0]))
            {
                currentNameList.Add(name);
            }
            else
            {
                currentNameList.Add(Char.ToUpper(name[0]) + name.Remove(0, 1));
            }
        }
    
       return string.Join(" ", currentNameList.ToArray()).Trim();
    }
