    string[] suggestContents = File.ReadAllLines("csgo_items.txt");
    int lineCount = 0;
    int mostSimilar = 0;
    int currentSimilar = 0;
    string[] splitLine = message.Split("_".ToCharArray());
    //Dictionary<int, int> suggestItem = new Dictionary<int, int>();
    List<string> suggestedItems = new List<string>();
    foreach (string line in suggestContents)
    {
        for(int i = 0; i < splitLine.Length; i++)
        {
            if(line.ToLower().Contains(splitLine[i].ToLower()))
            {
                currentSimilar++;
            }
        }
        if(currentSimilar > mostSimilar)
        {
            //We clear the current list, it is no longer needed, we have better match
            //List<int> suggestList = new List<int>();
            suggestedItems.Clear();
            
            mostSimilar = currentSimilar;
            
            //add current line to array.
            suggestedItems.Add(line);
        }
        else if(currentSimilar == mostSimilar)
        {
            //if another match simply add to list without clearing it.
            suggestedItems.Add(line);
        }
        lineCount++;
        currentSimilar = 0;
    }
