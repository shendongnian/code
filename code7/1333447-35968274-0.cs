    string rawWords = "New,Open,Exit,Copy,Cut,Paste,Help,About,";
    string rawGroupCounts = "3,3,2,"; // string of numbers
    List<int> groupCounts = rawGroupCounts.Split(new char[] { ',' }, 
        StringSplitOptions.RemoveEmptyEntries).
        ToList().ConvertAll(rawValue => Int32.Parse(rawValue));
    List<string> words = rawWords.Split(new char[] { ',' }, 
        StringSplitOptions.RemoveEmptyEntries).ToList();
    List<List<string>> wordGroups = new List<List<string>>();
    if (groupCounts.Count > 0)
    {
        int skipCounter = 0;
        groupCounts.ForEach(count =>
        {
            wordGroups.Add(words.Skip(skipCounter).Take(count).ToList());
            skipCounter += count;
        });
    }
    textBox1.Text = string.Join(Environment.NewLine, 
        wordGroups.ConvertAll(group => string.Join(", ", group)));
