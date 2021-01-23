    var result = db.Status
                   .GroupBy(s=>s.UserId)
                   .Select(gr=>new User_DTO
                   {
                       UserId = gr.Key,
                       // This probably should change
                       Last = gr.OrderByDescending(k=> k.DateTime).FirstOrDefault() 
                       // Place here the rest of the User_DTO properties
                   }).ToList();
