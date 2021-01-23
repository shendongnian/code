    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using SERVICE.Models;
    namespace ProjectX.Controllers
    {
        public class StudentController : Controller
        {
            // GET: Student
            public ActionResult Index()
            {
                ProjectX.DAL.ProjectContext db = new ProjectX.DAL.ProjectContext();
                // DAL is Data Access Layer Folder's name
                return View(Tuple.Create<Student, IEnumerable<Student>>(new Student(), db.Student.ToList()));
            }
        }
    }
