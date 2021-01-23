    var list = new List<int[]>();
    using (StreamReader streamReader = ...)
    {
        string line;
        string sectionName = null;
        while (null != (line = streamReader.ReadLine()))
        {
            var sectionMatch = Regex.Match(line, @"\s*\[\s*(?<NAME>[^\]]+)\s*\]\s*");
            if (sectionMatch.Success)
            {
                sectionName = sectionMatch.Groups["NAME"].Value;
            }
            else if (sectionName == "HRData")
            {
                // You can process lines inside the `HRData` section here.
                // Getting the numbers in the line, and adding to the list, one array for each line.
                var nums = Regex.Matches(line, @"\d+")
                    .Cast<Match>()
                    .Select(m => m.Value)
                    .Select(int.Parse)
                    .ToArray();
                list.Add(nums);
            }
        }
    }
