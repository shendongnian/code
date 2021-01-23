    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication93
    {
        class Program
        {
            static void Main(string[] args)
            {
                Letter newLetter = new Letter();
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Rows.Add(new object[] {1,"Destination1"});
                dt.Rows.Add(new object[] {2,"Destination2"});
                dt.Rows.Add(new object[] {3,"Destination3"});
                dt.Rows.Add(new object[] {4,"Destination4"});
                newLetter.Destinations = dt.AsEnumerable().Select(x => new Destination()
                {
                    Id = x.Field<int>("Id"),
                    Name = x.Field<string>("Name")
                }).ToList();
            }
        }
        public class Letter
        {
            public int Id { get; set; }
            public string Topic { get; set; }
            public string content { get; set; }
            public List<Destination> Destinations { get; set; }
        }
        public class Destination
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
     
    }
