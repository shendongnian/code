    var lst = new List<Student>();
    lst.Add(new Student { Name = "Joe", Age = 23 });
    lst.Add(new Student { Name = "John", Age = 28 });
    lst.Add(new Student { Name = "Jane", Age = 21 });
    lst.Add(new Student { Name = "John", Age = 15 });
    var vals = GetDistinctValues(lst, "Name"); // here
