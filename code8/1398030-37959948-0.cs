    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            Student obj = new Student();
            byte[] bytes = System.IO.File.ReadAllBytes("F:\\test.txt");
            string ba = Convert.ToBase64String(bytes);
            var s1 = new Student { Name = "Student1", Address = "Address1", ByteArray = ba };
            var s2 = new Student { Name = "Student2", Address = "Address2", ByteArray = ba };
            var s3 = new Student { Name = "Student3", Address = "Address3", ByteArray = ba };
            obj.StudentList = new List<Student>() { s1, s2, s3 };
            return View(obj);
        }
        [HttpGet]
        public FileResult DownloadAction(string file)
        {
            byte[] fileBytes = Convert.FromBase64String(file);
            string fileName = "test.txt";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
