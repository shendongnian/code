    public bool IsPermutation(IEnumerable<int> list,IEnumerable<int> subList)
        {
            var grpListCnt = list.GroupBy(num => num).ToDictionary(grp => grp.Key, grp => grp.Count());
            var subGroupCount = subList.GroupBy(num => num).ToDictionary(grp => grp.Key, grp => grp.Count());
            foreach(var keypair in subGroupCount)
            {
                if (!(grpListCnt.ContainsKey(keypair.Key) && 
                                  grpListCnt[keypair.Key] >= keypair.Value))
                    return false;
            }
            return true;
        }
