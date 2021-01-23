    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication58
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable employeesTable = new DataTable();
                employeesTable.Columns.Add("EmpID", typeof(int));
                employeesTable.Columns.Add("EmpName", typeof(string));
                employeesTable.Rows.Add(new object[] {1, "emp1"});
                employeesTable.Rows.Add(new object[] {2, "emp2"});
                employeesTable.Rows.Add(new object[] {3, "emp3"});
                DataTable departmentTable = new DataTable();
                departmentTable.Columns.Add("DeptID", typeof(int));
                departmentTable.Columns.Add("DeptName", typeof(string));
                departmentTable.Rows.Add(new object[] {1, "dept1"});
                departmentTable.Rows.Add(new object[] {2, "dept2"});
                departmentTable.Rows.Add(new object[] {3, "dept3"});
                DataTable relationTable = new DataTable();
                relationTable.Columns.Add("RelationID", typeof(int));
                relationTable.Columns.Add("EmpID", typeof(int));
                relationTable.Columns.Add("DeptID", typeof(int));
                relationTable.Rows.Add(new object[] {1, 1, 1});
                relationTable.Rows.Add(new object[] {2, 1, 2});
                relationTable.Rows.Add(new object[] {3, 2, 3});
                relationTable.Rows.Add(new object[] {4, 3, 1});
                relationTable.Rows.Add(new object[] {5, 3, 3});
                var joinTables =
                   (from r in relationTable.AsEnumerable()
                   join e in employeesTable.AsEnumerable() on r.Field<int>("EmpID") equals e.Field<int>("EmpID")
                   join d in departmentTable.AsEnumerable() on r.Field<int>("DeptID") equals d.Field<int>("DeptID")
                   select new { 
                       relationID = r.Field<int>("RelationID"), 
                       employeeID = e.Field<int>("EmpID"),
                       employeeName = e.Field<string>("EmpName"),
                       department = d.Field<string>("DeptName")
                   })
                   .ToList();
                var results = joinTables.GroupBy(x => x.employeeID).Select(y => new {
                   employee = new {
                       empID = y.FirstOrDefault().employeeID,
                       empName = y.FirstOrDefault().employeeName,
                       Dept1 = y.Where(z => z.department == "dept1").Any() ? "yes" : "no",
                       Dept2 = y.Where(z => z.department == "dept2").Any() ? "yes" : "no",
                       Dept3 = y.Where(z => z.department == "dept3").Any() ? "yes" : "no"
                   }
                }).ToList();
            }
        }
    }
