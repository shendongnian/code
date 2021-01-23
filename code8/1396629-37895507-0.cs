       Database db = new Database();
        var people = db.GetTable<Person>();
        //Modified line # 1
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
            db.Refresh(RefreshMode.OverwriteCurrentValues, person);
            //Modified line # 2
            db.Refresh(RefreshMode.OverwriteCurrentValues, enrollments);
            Console.WriteLine("Enroll Date After being refreshed:");
            foreach (var enrollment in person.Enrollment)
            {
                Console.WriteLine(enrollment.EnrollDate);
            }                
        } 
