    var selectedObj = db.Contracts.Where(x => dataBaseObjDictionary.ContainsKey(x.PersonRef) 
                    && dataBaseObjDictionary.Values.Any(
                    y => y.Any(a => x.FromDate <= a.DateTime 
                            && a.DateTime <=  x.UntilDate)
                           )
                    );
 
