    foreach (var test in testRecords)
    {
        if (clientResponses.Remove(test.Id))
        {
            test.IsResponded = true;
            if (clientResponses.Count == 0)
                break; // the remaining IsResponded values will remain unchanged 
        }
    }
