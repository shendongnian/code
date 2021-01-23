     var data = (from st in db.Student                     
                 join sub in db.Subject on st.StudentId equals  sub.st.StudentId into subjectsList
                 select new StudentModel
                 {
                     Name = st.Name,
                     Class= st.Class,
                     RollNo = st.RollNo,
                     SubjectList = subjectsList.ToList() //public ILIst<Subject> SubjectList {get;set;}
                 }).ToList();
