    Student _student = new Student();
    _student.Name = student.Name;
    _student.Surname = student.Surname;
    _student.Gender = student.Gender;          
    _student.BirthDate = student.BirthDate;
    Subject _subject = new Subject();
    if (!student.Subject.Any())
    {
        foreach (var item in student.Subjects)
        {
             // this is the ORM subject now, the names seem ambiguous 
             // but the important thing is you have are filling the List<Subject>
             // of the Student ORM entity with Subject ORM entities,
             // which will cause the ORM to handle the foreign key relationship
             // and insert items into the Subjects table
             _student.Subjects.Add(new Subject() { 
                 // fill properties here
             }
        }
    }
