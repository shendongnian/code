    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyMethod(5);
            }
            public static int WeekOf(DateTime? date)
            {
                if (date.HasValue)
                {
                    GregorianCalendar gCalendar = new GregorianCalendar();
                    int WeekNumber = gCalendar.GetWeekOfYear(date.Value, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                    return WeekNumber;
                }
                else
                    return 0;
            }
            public static List<ExpressionListDictionary> MyMethod(int weeknr)
            {
                using (DataAccessAdapter adapter = CreateAdapter())
                {
                    LinqMetaData meta = new LinqMetaData(adapter);
                    List<ExpressionListDictionary> q = (from i in meta.Test
                             where WeekOf(i.StartDate) == weeknr
                             select new ExpressionListDictionary()
                             {
                                    Id = "SomeId"
                             }
                    ).ToList();
                    return q;
                }
            }
            public static DataAccessAdapter CreateAdapter()
            {
                return new DataAccessAdapter();
            }
        }
        public class ExpressionListDictionary
        {
            public string Id { get; set; }
        }
        public class LinqMetaData
        {
            public List<LinqMetaData> Test {get;set;}
            public DateTime StartDate {get;set;}
            public int Id { get; set; }
            public LinqMetaData(DataAccessAdapter adapter)
            {
            }
        }
        public class DataAccessAdapter : IDisposable
        {
            public void Dispose()
            {
            }
        }
     
    }
    ​
