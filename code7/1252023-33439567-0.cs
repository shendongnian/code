    //1. Create new instance of Student
    Student student = new Student();
    //2. Get instance type
    var getType = student.GetType();
    //3. Get property FullName by name from type
    var fullNameProperty = getType.GetProperty("FullName",
            typeof(string));
            
    //4.  Set property value to "Some Name" using reflection
    fullNameProperty.SetValue(student, "Some Name");
