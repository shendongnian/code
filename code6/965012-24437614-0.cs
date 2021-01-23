    foreach (var item in firstDuplicate)
    {
        string matchingString = conLines.FirstOrDefault(r => r.Contains(item.firstParam) && r.Contains(item.secondParam));
        if(matchingString != null)
        {
            //CallYourMethod(matchingString);
        }
    }
