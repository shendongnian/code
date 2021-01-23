     class Program
    {
        static void Main(string[] args)
        {
            using(var db= new AW())
            {
                var e = db.Employees.First();
                e.JobTitle = "Web Developper";
                db.SaveChanges();
            }
        }
    }
