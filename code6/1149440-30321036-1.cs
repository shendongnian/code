    Cars = db.Cars
             .Where(item=>item.ClientId== id)
             .Select(c => new SelectListItem() 
                             { 
                               Text = c.Licence, 
                               Value = c.Id.ToString() 
                     });
