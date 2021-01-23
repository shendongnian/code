    foreach(DataRowView drv in dvCodes)
    {
        var codeType = drv["CodeType"].ToString().Trim();
        var code = drv["Code"].ToString().Trim();
        var description = drv["Description"].ToString().Trim();
        if(slCodes.ContainsKey(codeType))
        {
            slCodes[codeType].Add(code, description);
        }
        else
        {
            var subList = new SortedList<string, string>();
            subList.Add(code, description);
            slCodes.Add(codeType, subList);
        }
    }
