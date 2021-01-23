    // Get all checked items together
    var lookupIndices = sportCheckedListBox.CheckedIndices.Select(i => Convert.ToInt32(item.ToString()) + 1);
    // Find all matching sport numbers
    var queryResult = from sp in context.Sports
                      where lookupIndices.Contains(sp.sportnr)
                      select sp;
    // Now loop over the results
    foreach (var sport in queryResult)
    {
        myMember.Sports.Add(sport);
    }
    // save changes
