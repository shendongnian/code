    //distinct based on a specific property (in this case Name)
    List<Objects> listObjects = (from obj in db.Objects                             
                                    select obj).GroupBy(n => new {n.Name})
                                               .Select(g => g.FirstOrDefault())
                                               .ToList();
