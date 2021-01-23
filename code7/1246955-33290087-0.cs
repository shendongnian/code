    var x = db.ItemTemplates.Where(a => a.MainGroupId == mnId)
                            .Where(a => a.SubGruopId == sbId)
                            .FirstOrDefault();
    var ids = new List<int> { x.Atribute1, x.Atribute2, x.Atribute3, x.Atribute4 };
    var y = db.Atributes.Where(a => ids.Contains(a.AtributeId))
                        .Select(g => new
                                {  
                                   Id = g.AtributeId,
                                   Name = g.AtributeName,
                                   AtType = g.AtributeType,
                                   Options = g.atributeDetails
                                       .Where(w=>w.AtributeDetailId!=null)
                                       .Select(z => new 
                                             {
                                                Value=z.AtributeDetailId,
                                                Text=z.AtDetailVal
                                             })
                                })
         .ToList()
         .OrderBy(z=>ids.IndexOf(z.Id));
