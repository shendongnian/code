        Database db = new Database();
        var people = db.GetTable<Person>();
        var enrollments = db.GetTable<Enrollment>();
        
        var enrolledPeople = people.Where(o => o.Enrollment.Count > 0);
        foreach(var person in enrolledPeople)
        {
            Console.WriteLine("Original Enroll Date:");
            foreach (var enrollment in person.Enrollment)
            {
                Console.WriteLine(enrollment.EnrollDate);
                enrollment.EnrollDate = DateTime.Now;
            }
        
            person.Enrollment.Add(new Enrollment() );
        
    // beginning of rollback
            db.Refresh(RefreshMode.OverwriteCurrentValues, person);
            db.Refresh(RefreshMode.OverwriteCurrentValues, enrollments);
        
            for (int i= person.Enrollment.Count-1; i>=0; i--)
            {
                if (person.Enrollment[i].Id == 0)
                    person.Enrollment.RemoveAt(i);
            }
    // end of rollback   
 
            Console.WriteLine("Enroll Date After being refreshed:");
            foreach (var enrollment in person.Enrollment)
            {
                Console.WriteLine(enrollment.EnrollDate);
            }                
        }    
