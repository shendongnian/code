    var student = new Student();
    student.Name = "Student1";
    student.Courses = new List<Course>() { new Course() { Name = "English" } };
    
    MySettings settings = new MySettings();
    settings.Students = new List<Student>();
    settings.Students.Add(student);
    
    MySerializer.ToFile<MySettings>(settings, @"c:\temp", "settings.xml"); // serialize to c:\temp\settings.xml
    
    settings = MySerializer.ToObject<MySettings>(@"c:\temp", "settings.xml"); // deserialize to c:\temp\settings.xml
