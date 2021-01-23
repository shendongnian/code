    string[] WordList = null;
    for (int i = 0; i < FileEntries.Length; i++)
    {
        WordList = File.ReadAllLines(FileEntries[i]);
        foreach (string s in WordList)
            Console.WriteLine(s + " .. " + i);
    }
