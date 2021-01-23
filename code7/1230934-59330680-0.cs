    private static List<string> GencoAnagrams(List<string> textList)
        {
            var listCount = textList.Count;
            if (listCount == 1) return textList;
            for (var j = 1; j < listCount; j++)
            {
                for (var i = 0; i < j; i++)
                {
                    if (string.Concat(textList[j].OrderBy(x => x)).Equals(string.Concat(textList[i].OrderBy(y => y))))
                    {
                        textList.RemoveAt(j);
                        --listCount;
                        --j;
                        if (listCount == 1) break;
                    }
                }
                if (listCount == 1) break;
            }
            return textList;
        }
