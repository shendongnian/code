    var query = (from element in names
                            group element by new { element.Id, element.Name } into g
                            select new
                            {
                                Id = g.Key.Id,
                                Name = g.Key.Name,
                                Count = g.Count()
                            }).Where(p=>p.Count > 1).ToList();
    
                List<int> idToChange = new List<int>();
                for (int i=0; i < names.Count; i++)
                {
    
                    if (query.Select(p => p.Id).Contains(names[i].Id))
                    {
                        if (idToChange.Contains(names[i].Id))
                            names[i].Name = "null";
                        else
                            idToChange.Add(names[i].Id);
                    }
                }
