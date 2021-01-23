    var query = (from annonce in newresults
                group annonce by new { annonce.Id, annonce.Name }
                into grouping
                select new Ville 
                {
                     ID = grouping.Key.Id, 
                     Name = grouping.Key.Name, 
                     Nombre = grouping.Count() 
                }).OrderByDescending(x=> x.Nombre);
