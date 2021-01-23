    int counter = 0;
    int eachCounter = 0;
    foreach (var item in filteredList[0].subcategories)
    {
        // item is filteredList[0].subcategories[0], filteredList[0].subcategories[1] and so on.
        int questionsCounter = item.questionanswer.Count;
        eachCounter++;
        if (eachCounter.Equals(questionsCounter))
        {
            counter++;
            eachCounter = 0;
        }
    }
