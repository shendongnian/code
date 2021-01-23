    class Teacher
    {
        Student student = new Student();
        
        // Get the unique string from the 2nd class
        public string namef1
        {
            get { return student.Name; }
        }
        // Get the unique string from the 1st class that's already stored in the 2nd class
        public string UCourseName
        {
            get { return student.coursef1; }
        }
        // Set the string for the third class
        private string namet = "Sally";
        public string Namet
        {
            get { return namet; }
        }
    }
