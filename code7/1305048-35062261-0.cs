    IEnumerable<StudentDB> StudentDbs = GetAllStudentFromDB();
    IEnumerable<Student> Students = new StudentDbs.Select(student => ConvertToDto(student));
    private Student ConvertToDto(StudentDB)
    {
        return new Student 
        { 
            StudentId = StudentId, 
            Name = Name, 
            City = City, 
            BirthDate = BirthDate.DateTime };
    }
    <DataGrid ItemsSource="{Binding Students, Mode=TwoWay}" AutoGenerateColumns="True">
