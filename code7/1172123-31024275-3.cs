    var students = new List<Student>();
    foreach (var line in File.ReadLines("C:/Users/Y400/dDesktop/CTPrac/CTPrac/input.txt"))
    {
        var parts = line.Split(new[]{';', ' '}).ToList();
        students.Add(new Student()
        {
            Id = parts[0],
            Marks = parts.GetRange(1, 4)
        });
    }
