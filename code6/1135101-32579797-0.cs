    public void ListStudents()
        {
            foreach (Student s in this.Students)
            {
               Console.WriteLine("{0} {1}", s.FirstName, s.LastName);
            }
        }
