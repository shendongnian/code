    Cars = db.Cars
             .Select(c => new SelectListItem() 
                             { 
                               Text = c.Licence, 
                               Value = c.Id.ToString() 
                    }).ToList()
             .Where(item=>item.ClientId== id)
