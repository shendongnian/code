    Dictionary<Guid, Attorney> Attorneys = CreateDictionaryFrom(msg.CaseDocument.Attorneys);
    List<Attorney> CaseDefendantAtt = new List<Attorney>();
    List<Guid> AttorneyID = new List<Guid>();
    foreach (var s in msg.CaseDocument.Defendants)
    {
         AttorneyID.AddRange(s.Attorneys);               
    }
    
    foreach (var p in AttorneyID)
    {
         var z = Attorneys[p];
         if (z != null)
         {
             CaseDefendantAtt.Add(z);
         }
     }
