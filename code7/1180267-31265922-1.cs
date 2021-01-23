    int eachCounter = 0;
    for(int i = 0; i < filteredList[0].subcategories[i].questionanswer.Count; i++)
    {
        int questionsCounter = filteredList[0].subcategories[i].questionanswer.Count;
        eachCounter++; // I am not sure why you are doing this or what the purpose is
        if (eachCounter.Equals(questionsCounter))
        {
            eachCounter = 0;
        }
    }
