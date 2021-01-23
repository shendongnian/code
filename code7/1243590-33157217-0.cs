    var instance = GetAcademicDetailsOfCity();
    var school = instance as School;
    if (school != null)
    {
         // do school  specific tasks
    }
    
    var teacher = instance as Teacher;
    if (teacher != null)
    {
         // do teacher  specific tasks
    }
    
    var student = instance as Student;
    if (student != null)
    {
         // do student specific tasks
    }
