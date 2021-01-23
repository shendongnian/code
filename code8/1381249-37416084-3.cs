    public BasicSubstanceViewModel GetBasicSubstance(string partNumber,  string version, int nodeID, int parentID )
    {
        IMDSDataContext dc = new IMDSDataContext();
        var spResult = dc.spGetBasicSubstance( partNumber, version, nodeID, parentID).ToList();
    
        if(!spResult.Any())
        {
            return null;
        }
    
        var firstPart = spResult[0];
    
        var result = new BasicSubstanceViewModel
        {
            NodeID = firstPart.NodeID,
            CASNumber = firstPart.CASNumber,
            EINECSCode = firstPart.EINECSCode,
            EUIndex = firstPart.EINECSCode,
            Duty = firstPart.Duty,
            Prohibited = firstPart.Prohibited,
            Unwanted = firstPart.Unwanted,
            IsReach = firstPart.ISReach,
            SubstanceName = firstPart.SynonymName,
            GroupName = spResult.Select(p => new GroupName { Name = p.GroupName }).ToList(),
            Portion = firstPart.Portion
        }
    
        return result;
    }
