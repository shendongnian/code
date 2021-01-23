    string[] lines = System.IO.File.ReadAllLines("../../Privileges.txt");
    
    string[][] names = new string[lines.Length][];
    for (int i = 0; i < lines.Length; i++)
    {
        names[i] = lines[i].Split(',');
    }
