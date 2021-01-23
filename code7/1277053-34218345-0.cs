               List<int> matchedIDs = new List<string>();
                foreach (var item in tupleList)
                {
                    if (matchedIDs.contains(item.ID))
                    {
                        // do something
                    }
                    else
                    {
                        if (processed) // process the records and if process then add into list.
                        {
                            matchedIDs.Add(item.ID);
                        }
                    }
                }
