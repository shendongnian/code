    public Student(string[] studentInformationArray)
    {
         string className = studentInformationArray[1];
         // rest of your code...
         int project1 = int.Parse(studentInformationArray[4]); // always prefer int.Parse() instead of Convert.ToInt32()
         // rest of your code...
         this.studentInformationArray = studentInformationArray;
    }
    public Student()
    {
        string[] defaultInformation = new string[12];
        // add information
        defaultInformation[0] = "some information";
        // ...
        new Student(defaultInformation);
    }
