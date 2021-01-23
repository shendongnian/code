    Student studentMatch = null;
    foreach (Student student in students)
    {
        if (student.Name.Contains(studentNameSearch))
        {
             studentMatch = student;
             break;
        }
    }      
    if (studentMatch == null)
    {
         Console.WriteLine("Student name not found");
    }
    else
    {
        Console.WriteLine(studentMatch.ToString());
    }
