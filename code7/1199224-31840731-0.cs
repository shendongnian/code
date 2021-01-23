    var matchinginterviews = new List<Interview>();
    foreach (var inter in MyInterviewEnumerable)
    {
        foreach (var note in inter.NoteCollection)
        {
            foreach (string keyword in keywordList)
            {
                if (note.NoteText.IndexOf(keyword) != -1)
                {
                    matchinginterviews.Add(inter);
                }
            }
        }
    }
