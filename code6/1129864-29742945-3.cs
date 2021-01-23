        [HttpPost]
        public PartialViewResult AllStudent(IEnumerable<long> Objs)
        {
          var students = (from q in db.ACD_UNI_STUDENTS
                          where Objs.Contains(q.UNIQUE_ID)
                          select q).ToList();
          return PartialView(students);
        }
        ...
