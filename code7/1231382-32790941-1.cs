    var p2 = p1.Where(p => String.IsNullOrEmpty(p.Error) && !String.IsNullOrEmpty(p.Name) 
                       && !String.IsNullOrEmpty(p.Age))
               .Union(p1.Where(ip => !String.IsNullOrEmpty(ip.Error) 
                       && String.IsNullOrEmpty(ip.Name) && String.IsNullOrEmpty(ip.Age)))
               .ToArray();
