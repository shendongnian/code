    class Person {
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
    
    var orderedStudents = students.OrderBy(x => x.FacultyNumber).Select(x => new Person { Name = x.Name, Lastname = x.Lastname});
    var orderedWorkers = workers.OrderByDescending(x => x.moneyPerHour).Select(x => new Person { Name = x.Name, Lastname = x.Lastname});
    var mergedList = orderedStudents.Concat(orderedWorkers).ToList();
