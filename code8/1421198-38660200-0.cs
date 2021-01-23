    var result = new List<List<PRM>>();
    for (int x = 0; x <= multiUPC.Count()-1 ; x ++)
                {
    
                     result.Add( new List<PRM> { new PRM((multiUPC[x]),
                                   this.ModelMap[PRP.GetPropertyName(() => s.SKu)],
                                   this.ModelMap[PRP.GetPropertyName(() => s.UPCD)],
                                   this.ModelMap[PRP.GetPropertyName(() => s.SKUD)],
                                   this.ModelMap[PRP.GetPropertyName(() => s.Dep)]) });
    
                }
    
    return result
