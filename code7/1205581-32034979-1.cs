    students.SelectMany(arg => arg.Subject.Split(new []{','})) // split the Subject-property on commas
            .Select(arg => arg.Trim()) // get rid of the whitespaces after commas
            .GroupBy(arg => arg) // you can inject an equality comparer here, to achieve case insenstive grouping
            .Select(arg => new
                           {
                             Subject = arg.Key,
                             Count = arg.Count()
                           }); // TODO output these objects to your console..
