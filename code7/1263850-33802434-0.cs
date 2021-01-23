    public ActionResult Update()
        {
            string studentId = Request.QueryString["stuId"].ToString();
            StudentManagerEntitie objentity = new StudentManagerEntitie();
            StudentDetail objstudentdetail = new StudentDetail();
            objstudentdetail = (from data in objentity.StudentDetails
                                where data.Id == studentId
                                select data).FirstOrDefault();
            
            _objstudentdetail .Id = studentId;
           objentity.SaveChanges();
        }
