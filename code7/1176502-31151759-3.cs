    public class StudentInfo
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public Property[] Properties { get; set; }
        public string StudentName
        {
            get { return name; }
        }
        public string[] HairColors
        {
            get
            {
                return (Properties ?? Enumerable.Empty<Property>()).Select(p => p.hair).ToArray();
            }
        }
        public string HairColorCSV
        {
            get { return string.Join(",", HairColors); }
        }
        public string[] MathGrades
        {
            get
            {
                return (Properties ?? Enumerable.Empty<Property>()).SelectMany(p => p.Grades ?? Enumerable.Empty<Grade>()).Select(g => g.Math).ToArray();
            }
        }
        public string MathGradeCSV
        {
            get { return string.Join(",", MathGrades); }
        }
    }
