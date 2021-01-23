    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable Questions = new DataTable();
                Questions.Columns.Add("Id", typeof(int));
                Questions.Columns.Add("Category", typeof(string));
                Questions.Columns.Add("Topic", typeof(string));
                Questions.Columns.Add("Store1Rating", typeof(int));
                Questions.Columns.Add("Store2Rating", typeof(int));
                Questions.Rows.Add(new object[] { 1,"Food","Pizza", 5, 6 });
                Questions.Rows.Add(new object[] { 2, "Food", "Pizza", 4, 5 });
                Questions.Rows.Add(new object[] { 3, "Food", "Ice Cream", 4, 5 });
                Questions.Rows.Add(new object[] { 4, "Beverage", "Beer", 3, 4 });
                Questions.Rows.Add(new object[] { 5, "Beverage", "Soda", 4, 5 });
                Questions.Rows.Add(new object[] { 6, "Food", "Pizza", 5, 6 });
                Questions.Rows.Add(new object[] { 7, "Food", "Pizza", 4, 5 });
                Questions.Rows.Add(new object[] { 8, "Food", "Ice Cream", 3, 4 });
                Questions.Rows.Add(new object[] { 9, "Beverage", "Beer", 4, 5 });
                Questions.Rows.Add(new object[] { 10, "Beverage", "Soda", 5, 6 });
                var summary = Questions.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Topic"))
                    .Select(x => new
                    {
                        id = x.FirstOrDefault().Field<int>("Id"),
                        category = x.FirstOrDefault().Field<string>("Category"),
                        topic = x.Key,
                        rating1 = x.Select(y => y.Field<int>("Store1Rating")).ToList().Average(),
                        rating2 = x.Select(y => y.Field<int>("Store2Rating")).ToList().Average()
                    }).ToList();
            }
        }
    }
    ​
