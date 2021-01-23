        // Initially you concat the three list to one list
        var combinedLists = (item.Requeridos.Concat(item.Informados)).Concat(item.Opcionais);
        // Then you group them by the Login. If there is any group with more that 1
        // element then you have the same login more that one time.
        var result = combinedLists.GroupBy(x=>x.Login)
                                  .Any(gr=>gr.Count()>1);
