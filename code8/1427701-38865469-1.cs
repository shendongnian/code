    var result = new
                {
                    CombineList = TypesList.Where( t => t.type == "Add")
                                            .Union(TypesList.Where( t => t.type == "Multiply"))
                                            .Select(a => new { names = a.name }),
                    DivisionList = TypesList.Where(t => t.method == "Division").Select(t=>t.names).ToList()
                };
