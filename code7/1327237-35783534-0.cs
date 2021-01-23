    public static bool SerializeStudentsFile(string fileStorageLoc) 
    {
        var jsonStudents = JsonConvert.SerializeObject(StudentsList);
        System.IO.File.WriteAllText(fileStorageLoc, jsonStudents);
        return true;
    }
    
    public static List<Student> DeserializeStudentsFile()
    {
        List<Student> studentList;
        if (!System.IO.File.Exists(STUDENTS_FILENAME))
        {
            var studentFile = System.IO.File.Create(STUDENTS_FILENAME);
            studentFile.Close();
        }
    
        var studentContentsFile = System.IO.File.ReadAllText(STUDENTS_FILENAME);
        var studentContentsFileDeserialized = JsonConvert.DeserializeObject<List<Student>>(studentContentsFile);
    
        if (null != studentContentsFileDeserialized) return studentContentsFileDeserialized;
    
        studentList = new List<Student>();
        return studentList;
    }
