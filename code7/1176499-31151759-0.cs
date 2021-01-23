    public class StudentInfo
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public Property[] Properties { get; set; }
        public string StudentName {
            get{ return String.Format ("{0}", name); }
        }
        public string HairColor {
            get{ return String.Format ("{0}", (Properties ?? Enumerable.Empty<Property>()).Select(p => p.hair).FirstOrDefault()); }
        }
        public string MathGrade {
            get { return String.Format("{0}", (Properties ?? Enumerable.Empty<Property>()).SelectMany(p => p.Grades ?? Enumerable.Empty<Grade>()).Select(g => g.Math).FirstOrDefault()); }
        }
    }
