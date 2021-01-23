    var i = new List<Student>();
    i.Add(new Student { Id = 1, Name = "Maddy", Subject = "English", Marks = 87 });
    i.Add(new Student { Id = 1, Name = "Maddy", Subject = "Science", Marks = 81 });
    i.Add(new Student { Id = 2, Name = "Mathew", Subject = "Maths", Marks = 83 });
    i.Add(new Student { Id = 2, Name = "Mathew", Subject = "Science", Marks = 80 });
    var students = i.GroupBy(p => p.Id).ToDictionary(group => group.Key, group => group.Select(p => p.Marks).Average());
    var maxStudent = students.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
