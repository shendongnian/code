    var cars = new List<Cars>();
    cars.Add(new Cars());
    cars.Add(new Cars());
    cars.Add(new Cars());
    cars.Add(new Cars());
    var student = new List<Student>();
    student.Add(new Student() { c = cars });
    var root = new MyRoot();
    root.p = student;
