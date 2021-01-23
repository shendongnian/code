    IEnumerable<SelectListItem> selectList = db.LogBook
                                               .Where(i => i.TheName == xxx)
                                               .Select(c => new SelectListItem
                                               {
                                                  Text = c.ID,
                                                  Value = c.Day.ToShortDateString()                                                
                                               });
