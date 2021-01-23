    var infoIdLookup = IssuesMoreInfoList.ToLookup(i => i.ID);
    foreach(NSKData data in NSKDataList)
    {
        data.ToolTipInfoText = infoIdLookup[data.ID]
           .Select(i => i.IssueMoreInfoText)
           .FirstOrDefault();
    }
