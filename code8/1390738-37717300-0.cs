    ViewData["docFullDetails"] =
                new SelectList((from s in db.Doctors
                                select new
                                {
                                    FullName = (s.FirstName + s.Surname),
                                    ID = s.ID
                                }),
                "ID",
                "FullName");
