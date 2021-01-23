    public void ListStudents()
    {
        foreach(Student student in studentArrayList)
        {
            Console.WriteLine("Student {0} {1}", student.FirstName, student.LastName);
        }
    }
