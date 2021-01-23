    public ActionResult GridIndex()
        {
            StoreDepartmentBusinessLayer sdc = new StoreDepartmentBusinessLayer();
            List<dynamic> PivotList = sdc.GetData();
            List<string> columns = new List<string>();
            columns.Add("Store ID");
            columns.Add("Store Name");
            DepartmentBusinessLayer dbl = new DepartmentBusinessLayer();
            List<Department> Departments = dbl.Departments.Where(x => x.Active==1 && x.Calculation==0).ToList();
            foreach (Department LoopDept in Departments)
            {
                char[] DeptVertical = LoopDept.DeptName.ToCharArray();
                string DeptVerticalString = string.Join(Environment.NewLine, DeptVertical);
                //this one works ok for 0 and 1
                columns.Add(DeptVerticalString);
            }
            ViewBag.Columns = columns;
            return View(PivotList);
        }
