            if (open.Count == close.Count)
            {
                var listCount = open.Count;
                for (var i = 0; i < listCount; i++)
                {
                    if (open[i] != close[i])
                    {
                    }
                    else
                    {
                        return "failed";
                    }
                }
            }
            else
            {
                return "count failed";
            }
            return "passed";
