    ViewBag.CampusList = new SelectList(
                                        new List<string> { "CRA","DRA","MRA","PRA"},
                                        campus  // selected value 
                                       );
        ViewBag.FyList = new SelectList(
                                        new List<string> {"FY15","FY16" },
                                        ,fy    // selected value
                                       );
