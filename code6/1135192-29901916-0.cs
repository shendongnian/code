    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication4
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            List<Employee> employees = new List<Employee>();
            private void button1_Click(object sender, EventArgs e)
            {
                con.Open();
                cmd = new SqlCommand("SELECT Emp_FName, Emp_LName, T_Subject FROM Employee WHERE Emp_Position = 'Teacher'", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee newEmployee = new Employee();
                    employees.Add(newEmployee);
                    newEmployee.sub = rdr["T_Subject"].ToString();
                    newEmployee.fname = rdr["Emp_FName"].ToString();
                    newEmployee.lname = rdr["Emp_LName"].ToString();
                    newEmployee.fulname = fname + ' ' + lname;
                }
                Dictionary<string, List<Employee>> dict = employees.AsEnumerable()
                    .GroupBy(x => x.sub, y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
                rdr.Close();
                con.Close(); 
            }
        }
        public class Employee
        {
            public string sub {get; set;}
            public string fname { get; set; }
            public string lname { get; set; }
            public string fulname { get; set; }
        }
    }
