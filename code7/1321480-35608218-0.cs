        public class Result
        {
            public DateTime col1 { get; set; }
            public int col2 { get; set; }
            public int col3 { get; set; }
            public int col4 { get; set; }
            public int col5 { get; set; }
        }
        public static void Main()
            {
                List<Result> listTest = new List<Result>();
                listTest.Add(new Result() { col1 = DateTime.Now, col2 =1, col3 =3, col4 =5, col5=11});
                listTest.Add(new Result() { col1 = DateTime.Now.AddYears(-1), col2 = 1, col3 = 3, col4 = 5, col5 = 11 });
                listTest.Add(new Result() { col1 = DateTime.Now.AddYears(-1), col2 = 1, col3 = 3, col4 = 5, col5 = 11 });
    
                var maxYearLessThanCurrentYear = listTest.Where(x => x.col1.Year < DateTime.Now.Year).Select(x => x.col1.Year).Max();
    
                var output = listTest.Where(x => x.col1.Year < DateTime.Now.Year)
                                   .Select( x => new  { x.col2, x.col3, x.col4, x.col5, maxYearLessThanCurrentYear })
                                   .GroupBy(x=>x.maxYearLessThanCurrentYear)
                                   .Select(x => new Result
                                   {
                                       col1 = new DateTime(x.Key, 1, 1) ,
                                       col2 = x.Sum(y => y.col2),
                                       col3 = x.Sum(y => y.col3),
                                       col4 = x.Sum(y => y.col4),
                                       col5 = x.Sum(y => y.col5),
                                   })
                                   .FirstOrDefault();
         }
