                IList<string> words1 = new List<string>{...};
                var wordsWithLengthOf8 = words1.Where(w => w.Length == 8).ToList();
                IDictionary<string,string> wordsWithLengthOf8Dic = wordsWithLengthOf8.ToDictionary(w => w);
                IList<string> words2 = new List<string>{...};
                IList<string> matches = new List<string>();   
 
                for (int i = 0; i < wordsWithLengthOf8.Count; i++)
                {
                    var tupled = wordsWithLengthOf8[i].ConcatCheck();
                    var isMatch = wordsWithLengthOf8Dic.ContainsKey(tupled.Item1) && wordsWithLengthOf8Dic.ContainsKey(tupled.Item2);
                    if (isMatch)
                    {
                        matches.Add(wordsWithLengthOf8[i]);
                    }
                }
