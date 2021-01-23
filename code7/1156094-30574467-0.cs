    My model Contains:
     
            public int Id { get; set; }
    
            public string Name { get; set; }
    
            public long state { get; set; }
    
            public long city { get; set; }
    
            public string StateName { get; set; }
            public string Cityname { get; set; }
    
            public bool Status { get; set; }
      
    Controller Contains:
    
    
        public ActionResult Index()
            {
                ViewBag.state = new SelectList(DbEntity.tblStates, "Id", "State");
                return View();
            }
            public JsonResult Getcities(int id)
            {
                ViewBag.city = new SelectList(DbEntity.tblCities.Where(m=>m.sid==id),"Id","City");
                return Json(ViewBag.city,JsonRequestBehavior.AllowGet);
            }
           [HttpPost]
            public void SaveUser(User user)
            {
             
                if(user.Id!=0)
                {
                    var t = DbEntity.tblUsers.Where(m => m.Id == user.Id).FirstOrDefault();
                    t.Id = user.Id;
                    t.Name = user.Name;
                    t.State = user.state;
                    t.City = user.city;
                }
    
                else
                {
                    tblUser tblobj = new tblUser();
                    tblobj.Id = user.Id;
                    tblobj.Name = user.Name;
                    tblobj.State = user.state;
                    tblobj.City = user.city;
                    DbEntity.tblUsers.Add(tblobj);
                }
    
                DbEntity.SaveChanges();
    
            }
    
    
            public ActionResult DisplayList(User user)
            {
    
                 User objU = new User();
                List<User> u = new List<User>();
                List<tblUser> userlist = new List<tblUser>();
    
    
                u = (from a in DbEntity.tblUsers
                            join b in DbEntity.tblStates on a.State equals b.Id join c in DbEntity.tblCities on a.City equals c.Id
                            select new { a, b,c }).Where(p => p.a.Status == true).ToList().Select(p => new User()
                        {
                            Id = (int)p.a.Id,
                            Name = p.a.Name,
                            StateName = p.b.State,
                            state = (int)p.a.State,
                            city = (int)p.a.City,
                            Cityname = p.c.City
    
    
    
                        }).ToList<User>();
    
                return View(u);
            }
    
    View DisplayList.cshtml Contains:
    
    
    
    
            <div>
                <table>
                    <tr><td>Name</td><td>State</td><td>City</td><td>Action</td></tr>
                    @foreach (var item in Model)
                    {
    
                        <tr>
                            <td>@item.Name</td>
                            <td>@item.StateName</td>
                            <td>@item.city</td>
                           
                        </tr>
    
                    }
    
                </table>
    
            </div>
        }
