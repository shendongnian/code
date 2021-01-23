      private void CalculateRegs(List<DateTime> eventList)
            {
                Dictionary<DateTime, int> counts = eventList.GroupBy(x => x)
                     .ToDictionary(g => g.Key, g => g.Count());
    
                // merge with reglist
                for (int i = 0; i < counts.Count; i++)
                {
                    var el = counts.ElementAt(i);
                    if (RegsList.Count <= i)
                    {
                        RegsList.Add(counts.ElementAt(i).Value);
                    }
                    else
                    {
                        var tempNum = el.Value + RegsList.ElementAt(i);
                        RegsList[i] = tempNum;
                    }
                } 
            }
