    public class RegisterController : Controller
    {
        private UsersAndRolesDBContext db = new UsersAndRolesDBContext();
        
        public ActionResult Register()
        {
             ViewBag.Title = "Portal";
            var model = new RegisterModel
            {
                CustomerID = GetCustomerIds()
            };
            return View(model);
    }
    public class DbCustomerIds
        {
            public List<DbCustomerId> GetCustomerIds()
            {
                List<DbCustomerId> Customers = new List<DbCustomerId>();
                string queryString = "SELECT Id, Name FROM dbo.Customers";
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);
                DataSet customers = new DataSet();
                adapter.Fill(customers, "Customers");
                foreach (DataRow item in customers.Tables[0].Rows)
                {
                    DbCustomerId cid = new DbCustomerId();
                    cid.Id = Convert.ToInt32(item["Id"]);
                    cid.Name = Convert.ToString(item["Name"]);
                    Customers.Add(cid);
                }
                return Customers;
            }
        }
        private IEnumerable<SelectListItem> GetCustomerIds()
        {
            var DbCustomerIds = new DbCustomerIds();
            var customers = DbCustomerIds
                        .GetCustomerIds()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.Name
                                });
            return new SelectList(customers, "Value", "Text");
        }
            
