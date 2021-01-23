    public void getStudent()
        {
          List<Student> StudentList = new List<Student>();
          string nextVal = "y";
          while (nextVal == "N")
            {
               var student = new Student();
               Console.Write("Enter Your First Name: ");
               student.First_Name = Console.ReadLine();
               Console.Write("Enter Your Last Name: ");
               student.Last_Name = Console.ReadLine();
               StudentList.Add(student);
               Console.Write("Do you wnat to add more data(Y/N)");
               nextVal = Console.ReadKey().ToString();
            }
      }
