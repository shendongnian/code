    //To create a unique key (an string, which is a primitive type) combining the three values
    var keys=relationsCollection.Select(e=>e.Id+"-"+e.RelatedNodeId+"-"+ ((int)e.RelationType)).Distinct();
    var query=db.NWatchRelations.Where(r=>keys.Any(k=>k == (SqlFunctions.StringConvert((double)r.Id)+"-"+
                                                            SqlFunctions.StringConvert((double)r.RelatedNodeId )+"-"+ 
                                                            SqlFunctions.StringConvert((double)((int)r.RelationType)) ));
