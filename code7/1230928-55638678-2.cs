    public bool IsAnagram(string firstString, string secondString)
            {
                List<char> firstlist = new List<char>();
                firstlist.AddRange(firstString);
    
                List<char> secondlist = new List<char>();
                secondlist.AddRange(secondString);
    
                if (secondlist.Count != firstlist.Count)
                {
                    return false;
                }
    
                while (firstlist.Count != 0 && secondlist.Count != 0)
                {
                    foreach (var sec in secondlist)
                    {
                        foreach (var fir in firstlist)
                        {
                            if (char.ToUpperInvariant(sec) == char.ToUpperInvariant(fir))
                            {
                                firstlist.Remove(fir);
                                break;
                            }
                        }
                        secondlist.Remove(sec);
                        break;
                    }
                }
                if (firstlist.Count == secondlist.Count)
                    return true;
                return false;          
            }
