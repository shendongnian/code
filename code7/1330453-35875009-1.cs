    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using MVCTest.Models;
    
    namespace MVCTest.Controllers
    {
        public class Employee1Controller : Controller
        {
            private readonly EmployeeContext db;
            public Employee1Controller()
            {
                db = new EmployeeContext();
            }
            // GET: Employee1
            public ActionResult Details(int id)
            {
                EmployeeModel employee = db.Employees.Single(emp => emp.EmployeeId == id);
                return View(employee);
            }
        }
    }
