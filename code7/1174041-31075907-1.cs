    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                DataTable dta = new DataTable();
                dta.Columns.Add("Emp_Name", typeof(string));
                dta.Columns.Add("User_Shift", typeof(string));
                dta.Columns.Add("Shift_Emp_Status", typeof(string));
                dta.Columns.Add("Shift_Date", typeof(DateTime));
                dta.Rows.Add(new object[] {"John", "Morning", "abc", DateTime.Parse("1/1/15")});
                dta.Rows.Add(new object[] { "John", "Morning", "abc", DateTime.Parse("1/2/15") });
                dta.Rows.Add(new object[] { "John", "Afternoon", "abc", DateTime.Parse("1/3/15") });
                dta.Rows.Add(new object[] { "John", "Morning", "abc", DateTime.Parse("1/14/15") });
                dta.Rows.Add(new object[] { "John", "Morning", "abc", DateTime.Parse("1/15/15") });
                dta.Rows.Add(new object[] { "John", "Afternoon", "abc", DateTime.Parse("1/26/15") });
                dta.Rows.Add(new object[] { "Mary", "Morning", "abc", DateTime.Parse("1/15/15") });
                dta.Rows.Add(new object[] { "Mary", "Morning", "abc", DateTime.Parse("1/22/15") });
                dta.Rows.Add(new object[] { "Mary", "Evening", "abc", DateTime.Parse("1/23/15") });
                dta.Rows.Add(new object[] { "Mary", "Afternoon", "abc", DateTime.Parse("1/24/15") });
                dta.Rows.Add(new object[] { "Mary", "Morning", "abc", DateTime.Parse("1/25/15") });
                dta.Rows.Add(new object[] { "Mary", "Evening", "abc", DateTime.Parse("1/26/15") });
                DataTable displayTable = new DataTable();
                DateTime firstDayOfMonth = DateTime.Parse("6/1/15");
                int numberOfDaysInMonth = firstDayOfMonth.AddMonths(1).AddDays(-1).Day;
                DateTime dayCounter = firstDayOfMonth;
                displayTable.Columns.Add("Name",typeof(string));
                for(int i = 0; i < numberOfDaysInMonth; i++)
                {
                    displayTable.Columns.Add(dayCounter.ToShortDateString(), typeof(string));
                    dayCounter = dayCounter.AddDays(1);
                }
                var results = dta.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Emp_Name"))
                    .Select(x => new
                    {
                        name = x.Select(y => y.Field<string>("Emp_Name")).FirstOrDefault(),
                        shifts = x.Select(y => y.Field<string>("User_Shift")).ToList(),
                        days = x.Select(y => y.Field<DateTime>("Shift_Date")).ToList()
                    }).ToList();
                foreach (var row in results)
                {
                    string[] shifts = new string[numberOfDaysInMonth + 1];
                    shifts[0] = row.name;
                    for (int i = 0; i < row.days.Count; i++)
                    {
                        int dayOfMonth = row.days[i].Day;
                        string shift = row.shifts[i];
                        shifts[dayOfMonth] = shift;
                    }
                    DataRow shiftRow = displayTable.Rows.Add(shifts);
                }
                dataGridView1.DataSource = displayTable;
            }
        }
    }
    ​
