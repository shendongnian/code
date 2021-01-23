    public static class StudentExtensions
    {
        public static void SetGrades(this Student student, params int[] values)
        {
            foreach (int grade in values)
            {
                student.SetGrade(grade);
            }
        }
    }
