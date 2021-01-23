    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    namespace ConsoleApplicationXml
    {
        class Program
        {
            static void Main(string[] args)
            {
                var xDocument = XDocument.Load("Store.xml");
                //Get all employees that belong to "Fashion
                string departmentName = "Fashion";
       //compiles but get object variable not set
        var employees = (from emp in xDocument.Descendants("Employees")
                         where (emp.Parent.FirstAttribute.Value == departmentName)
                         select new Employee
                         {
                             DepartmentName = departmentName,
                             FirstName = emp.FirstAttribute.Value,
                             Surname = emp.LastAttribute.Value
                         }).ToList();
