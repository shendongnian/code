    CREATE PROCEDURE FETCHEMPLOYEES AS
    BEGIN
        SELECT * FROM EMPTABLE
    END
        
    CREATE PROCEDURE FETCHEMPLOYEE(@ID INT) AS
    BEGIN
      SELECT * FROM EMPTABLE WHERE ID = @ID
    END
    public class EmpModel
    {
        EmployeeEntities empdb = new EmployeeEntities();
       
        public List<EMPTABLE> GetEmployees()
        {
           return empdb.FETCHEMPLOYEES().ToList();  
        }
        public EMPTABLE GetEmployee(int? id)
        {
            return empdb.FETCHEMPLOYEE(id).ToList().Single();
        }
    }
    public class EmployeeController : Controller
    {
        Models.EmpModel mod = new Models.EmpModel();
        public ActionResult Index()
        {
            List<EMPTABLE> result = mod.GetEmployees();
            return View(result);
        }
        public ActionResult Details(int id)
        {
            EMPTABLE result = mod.GetEmployee(id);
            return View(result);
        }
    }
