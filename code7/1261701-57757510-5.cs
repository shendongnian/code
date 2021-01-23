    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
    }
    public class HomeController : Controller
    {
        private IList<EmployeeModel> employees = new List<EmployeeModel>();
        public HomeController()
        {
            for (int i = 0; i < 20; i++)
            {
                employees.Add(new EmployeeModel()
                {
                    Id = i + 1,
                    Name = "Name " + (i + 1).ToString(),
                    Family = "Family " + (i + 1).ToString(),
                });
            }
        }
        public ActionResult Index(string txtFilter)
        {
            txtFilter = txtFilter ?? "";
            var result = employees.Where(x => x.Name.Contains(txtFilter) || x.Family.Contains(txtFilter) || x.Id.ToString() == txtFilter);
            return View(result.ToList());
        }
        public void ExportToExcel(string txtFilter)
        {
            txtFilter = txtFilter ?? "";
            var result = employees.Where(x => x.Name.Contains(txtFilter) || x.Family.Contains(txtFilter) || x.Id.ToString() == txtFilter).ToList();
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(result))
            {
                table.Load(reader);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(table, "Employees");
                string myName = HttpContext.Server.UrlEncode("Employees.xlsx");
                MemoryStream stream = GetStream(wb);
                HttpContext.Response.Clear();
                HttpContext.Response.Buffer = true;
                HttpContext.Response.AddHeader("content-disposition", "attachment; filename=" + myName);
                HttpContext.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Response.BinaryWrite(stream.ToArray());
                HttpContext.Response.End();
            }
        }
        private MemoryStream GetStream(XLWorkbook excelWorkbook)
        {
            MemoryStream fs = new MemoryStream();
            excelWorkbook.SaveAs(fs);
            fs.Position = 0;
            return fs;
        }
    }
