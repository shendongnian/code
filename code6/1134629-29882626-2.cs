    static void Main(string[] args)
    { 
        var scienceProgram = new StudentProgram("science");
        scienceProgram.Add(new Student(
            "John", "Grodinskiy", "12/07/1996", 
            "Lesy Ukrainky 88", "Cherkasy", "58000", "Ukraine"));
        scienceProgram.Add(new Student(
            "Niko", "Rekun", "03/02/1995", 
            "Promyslova 86", "Velykiy Bychkiv", "90615","Ukraine"));
        scienceProgram.Add(new Student(
            "Veronica","Kran", "26/03/1991", 
            "Uzhgorodska 1", "Svalyava", "59432", "Ukraine"));
        ........
        Console.WriteLine(
            "The {0} program has {1} students",
            scienceProgram.Name, scienceProgram.NumberOfStudents);
         foreach (var student in scienceProgram.AllStudents)
             student.TakeTest();
    }
