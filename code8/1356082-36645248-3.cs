    public class EmployeeMetadata
    {
        [Required]
        public DateTime BirthDate { get; set; }
    }
    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee
    {
    }
    
        public ActionResult Index()
        {
            NorthwindEntities db = new NorthwindEntities();
            return View(db.Employees.First());
        }
