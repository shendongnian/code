        private string BuildRanges(List<DateTime> DateList)
        {
            string result = "";
            int start = 0;
            int end = 0;
            DateTime curr, prev;
            for (int i = 1; i <= DateList.Count; i++)
            {
                if (i < DateList.Count)
                {
                    curr = DateList[i];
                    prev = DateList[i - 1];
                    if (curr.Year == prev.Year && curr.Month == prev.Month && curr.Day == prev.Day + 1)
                    {
                        end = i;
                        continue;
                    }
                }
                if (start == end)
                {
                    result += DateList[start].ToString("MMM d, yyyy");
                }
                else
                {
                    result += DateList[start].ToString("MMM d") + "-" + DateList[end].ToString("d, yyyy");
                }
                result += "; ";
                start = end = i;
            }
            return result.Substring(0, result.Length - 2);
        }
