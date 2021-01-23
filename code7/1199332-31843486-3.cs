    var q = from p in m.ViewPersonCarRelations.AsEnumerable()                    
                    select (_mycondition == "0") ?
                        new 
                        {
                            FirstName = p.name,
                            LastName = p.Lname  
                        }
                        :
                        new 
                        {
                            LastName = p.Lname
                        };
