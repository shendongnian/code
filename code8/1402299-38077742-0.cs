    public class GradeBook
        {
            public GradeBook()
            {
                gradesList = new List<float>();
            }
    
            public void AddGrades(float grades)
            {
                gradesList.Add(grades);
            }
    
            List<float> gradesList;
    
            public List<float> GradesList
            {
                get
                {
                    return gradesList;
                }
    
                set
                {
                    gradesList = value;
                }
            }
        }
   
        public class GradeStatistics
        {
            public void MyMethod()
            {
                GradeBook aveg = new GradeBook();
               var x = aveg.GradesList;
            }
    }
