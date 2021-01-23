    students.SelectMany(arg => arg.Subject.Split(new []{','}))
            .GroupBy(arg => arg)
            .Select(arg => new
                           {
                             Subject = arg.Key,
                             Count = arg.Count()
                           });
