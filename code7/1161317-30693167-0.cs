                var res = from k1 in dict.Keys
                    from k2 in dict.Keys
                    where string.Compare(k1, k2) == -1 && 
                    dict[k1].Count == dict[k2].Count && !dict[k1].Any(x => !dict[k2].Contains(x)) && !dict[k2].Any(x => !dict[k1].Contains(x))
                    select new { k1, k2 };
