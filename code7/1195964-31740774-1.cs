     var values = "11,Standard(db=S,api=Standard),UI,1(db=1,api=STANDARD),Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.125 Safari/537.36,1010,9999,1000,9998.0,,1";
     var splitList = GetSplitList(values);
    
     public static List<string> GetSplitList(string values)
        {
            var splitList = new List<string>();
            var retValue = string.Empty;
            foreach (var value in values.Split(','))
            {
                if (!string.IsNullOrEmpty(retValue) && !value.Contains(")"))
                {
                    retValue += string.Format("{0},", value);
                    continue;
                }
                if (value.Contains("("))
                {
                    retValue += string.Format("{0},", value);
                    continue;
                }
                if (value.Contains(")"))
                {
                    retValue += value;
                    splitList.Add(retValue);
                    retValue = string.Empty;
                    continue;
                }
                splitList.Add(value);
            }
            return splitList;
        }
