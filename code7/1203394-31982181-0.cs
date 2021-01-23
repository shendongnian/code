    public string Studentbyteacher(long teacherId)
    {
        using (var context = new DbContext())
        {
            var students = 
                from teacherStudent in context.TeacherStudent.Where(x => x.TeacherID == teacherId)
                let studentId = teacherStudent.studentID
                let student = context.Student.Where(x => x.ID == studentId).Single()
                select student;
    
            return JsonConvert.SerializeObject(students);
        }
    }
