    var p1Err = p1.Where(p => String.IsNullOrEmpty(p.Error) && !String.IsNullOrEmpty(p.Name) 
                       && !String.IsNullOrEmpty(p.Age));
    var p1NoErr = p1.Where(p => !String.IsNullOrEmpty(p.Error) && String.IsNullOrEmpty(p.Name) 
                        && String.IsNullOrEmpty(p.Age));
    var p2 = p1Err.Union(p1NoErr)
                  .ToArray();
  
