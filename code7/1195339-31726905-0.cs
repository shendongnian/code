    internal class Program
    {
        private static void Main( string[] args )
        {
            Teacher teacher = new Teacher();
            Console.WriteLine("{0} and {1} are in {2}",
            teacher.Namef1, teacher.Namet, teacher.Course);
        }
        private class UCourse
        {
            // Set the unique string for the 1st class
            private readonly string course = "Computer Scienece";
            public string Course { get { return this.course; } }
        }
        private class Student
        {
            // Set the unique string for the 2nd class
            private readonly string _name = "zach";
            public string Name { get { return this._name; } }
            // Get the string from the 1st class
            private readonly UCourse _ucourse = new UCourse( );
            public string Coursef1 { get { return this._ucourse.Course; } }
        }
        private class Teacher
        {           
            private readonly Student _student = new Student( );
            // Get the unique string from the 1nd class
            public string Course { get { return this._student.Coursef1; } }
            // Get the unique string from the 2nd class
            public string Namef1 { get { return this._student.Name; } }
            // Set the unique string for the 3rd class
            private readonly string _namet = "Sally";
            public string Namet { get { return this._namet; } }
        }
    }
