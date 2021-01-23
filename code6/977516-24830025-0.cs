    for (int i = 0; i < myValues.Count; i++)
            {
                for (int x = 0; x < newOnly.Count; x++)
                {
                    if (!myValues.Contains(newOnly[x]) && !newValues.Contains(newOnly[x]))
                    {
                        newValues.Add(newOnly[x]);
                    }
                }
            }
