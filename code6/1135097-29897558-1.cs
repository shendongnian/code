    public void liststudents()
    {
        for (int i = 0; i < studentarraylist.Count; i++) 
        {
            Student currentStudent = (Student)studentarraylist[i];
            Console.WriteLine("Student First Name: {0}", currentStudent.FirstName); // Assuming FirstName is a property of your Student class
            Console.WriteLine("Student Last Name: {0}", currentStudent.LastName);
            // Output what ever else you want to the console.
        }
    }
