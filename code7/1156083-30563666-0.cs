    // Main class.  This doesn't do anything but spin up a new class
    // and tell it to get all student grades.
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new BTECGradeCalculator();
            calculator.GetAllStudentGrades();
        }
    }
