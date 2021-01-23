    var labelData = new Dictionary<string, Dictionary<string, LabelData>>();
    foreach (var listItem in configList)
    {
        labelData[listItem.ParentGroup] = 
            configList.Distinct().ToDictionary(x => x.Label.ToString(), row => new LabelData()
        {
            StartRange = Convert.ToInt32(listItem.StartRange.ToString()),
            EndRange = Convert.ToInt32(listItem.EndRange.ToString())
        });
    }
