      public void Print(bool letterGrades = false)
      {
         Console.WriteLine("Student\t\tGrade");
         Console.WriteLine("-------------------------------");
         foreach (Student student in this)
         {
            if (student != null)
            {
               Console.WriteLine(student.Name + "\t\t" + letterGrades? LetterGradeFromNumber(student.Grade) : student.Grade.ToString());
            }
          }
      }
