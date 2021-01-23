     public List<string> ProcessChatLog(List<string> history, List<string> potentialNew)
        {
            var lastChat = history.Last();  
            var lastChatIndex = history.Count - 1;
            var allIndexWithLastChat = potentialNew.Select((c, i) => new { chat = c, Index = i })
                                       .Where(x => x.chat == lastChat)
                                       .Select(x => x.Index).Reverse().ToList();       
            List<int> IndexToClear = new List<int>();
            bool overlapFound = false;
            foreach (var index in allIndexWithLastChat)
            {
                if (!overlapFound)
                {
                    int hitoryChatIndex = lastChatIndex;
                    IndexToClear.Clear();
                    for (int i = index; i > -1; i--)
                    {
                        if (potentialNew[i] == history[hitoryChatIndex])
                        {
                            IndexToClear.Add(i);
                            if (i == 0)
                            {
                                overlapFound = true;
                                break;
                            }
                            hitoryChatIndex--;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    IndexToClear.Clear();
                    break;
                }                             
            }
            if(IndexToClear.Count >0)
            {
                potentialNew.RemoveRange(IndexToClear.Min(), IndexToClear.Count);   
            }
         
            return history.Concat(potentialNew).ToList();
        }
