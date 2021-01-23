    foreach (string stringId in stringArray)
    {
        if (!string.IsNullOrWhiteSpace(stringId)) {
             intList.Add(Convert.ToInt32(stringId));
        }
        else {
          intList.Add(0);
        }
    }
