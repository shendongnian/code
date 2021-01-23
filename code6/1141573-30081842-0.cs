    public void PrintStudent()
    {
        int i = AllStudents.Count - 1; //last student
        Student thisStudent = this.AllStudents[i];
        string fName = thisStudent.firstName;
        string lName = thisStudent.lastName;
        Console.WriteLine(string.Format("{0}. {1} {2}", i+1, fName, lName));
    }
    public void DisplayAll(List<Student> someStudents)
    {
        StringBuilder formattedStudents = new StringBuilder();
        int lastIndex = someStudents.Count - 1;
        for (int i = 0; i < someStudents.Count; i++)
        {                
            if (i == 0)
            {
                formattedStudents.AppendLine("Complete List of Students:");                    
            }
            string fName = someStudents[i].firstName;
            string lName = someStudents[i].lastName;
            formattedStudents.AppendLine(string.Format("{0}. {1} {2}", i + 1, fName, lName));
            if (i == lastIndex)
            {
                formattedStudents.AppendLine();
                formattedStudents.AppendLine("Have a nice day.");
            }
                
        }
        Console.Write(formattedStudents);
    }
