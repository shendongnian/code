    public ActionResult Index(string currentFilter=null, string search=null, string searchBy=null, int? page=1)
        {
            var student = from d in db.Student_vw
                          where d.is_active == true
                          select d;
            //if (searchBy == "default")
            //{
            //    student = student.OrderByDescending(x => x.ID_Number);
            //}
    
            //searching of an item
            if (!String.IsNullOrEmpty(search))
            {
                student = student.Where(x => x.ID_Number.Contains(search) || x.student_fname.Contains(search)
                    || x.student_lname.Contains(search) || x.section_name.Contains(search) || x.course_name.Contains(search)
                    || x.student_address.Contains(search) || x.batch_name.Contains(search) || x.adviser_fname.Contains(search) || x.adviser_lname.Contains(search) || x.student_email_add.Contains(search));
            }
            //else {
            //    student = student.OrderByDescending(x => x.ID_Number);
            //}
            ViewBag.CurrentFilter = search;
    
            int pageSize = 25;
            int pageNumber = (page ?? 1);
    
            var returnMe = student.OrderByDescending(x => x.ID_Number).ToPagedList(pageNumber, pageSize);
    
            return View(returnMe);
        }
