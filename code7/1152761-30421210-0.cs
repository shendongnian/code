    for (int i = OriginalList.Count - 1; i >= 0; i--)
      {
        if(DuplicateList.Exists(x=>x.BId == OriginalList[i].BId)
            OriginalList.RemoveAt(i)
      }
