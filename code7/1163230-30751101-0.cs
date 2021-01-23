    var listA = from s in Students
                select new { FirstName = s.FirstName, LastName = s.LastName };
    var listB = from t in Teachers
                select new { FirstName = t.FirstName, LastName = t.LastName };
    Console.WriteLine(listA.First().GetType().Name);
    Console.WriteLine(listB.First().GetType().Name);
