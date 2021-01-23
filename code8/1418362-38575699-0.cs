    List<string> WordList = null;
    for (int i = 0; i < FileEntries.Length; i++)
    {
        WordList = File.ReadLines(FileEntries[i]).ToList();
        foreach (string s in WordList)
            Console.WriteLine(s + " .. " + i);
        // If you want also the line number then you could just use normal for..loop and C# 6.0 syntax
        for(int o = 0; o < WordList.Count(); o++)
            Console.WriteLine($"File:{i} at line {o} is ..{WordList[o]}");
 
        
    }
