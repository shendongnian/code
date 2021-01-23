    var result = new Collection<object>();
    
    result.Add(list.Select(s => new
                   {
                       s.ID,
                       string.Join(",", s.Users.ToArray())   
                   })
               );
