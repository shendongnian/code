    public ActionResult Import(HttpPostedFileBase excelfile)
        {
            //Code to get data from Excel sheet
            for( int row =2; row <=range.Rows.Count; row++)
                {
                    Employeelist emp = new Employeelist();
                    emp.ID =((Excel.Range)range.Cells[row,1]).Text;
                    obj.Add(emp);
                }
            TempData["doc"] = obj;
            return View("success", TempData["doc"]);
        }
    [HttpPost]
    public ActionResult Save(List<Employeelist> empLIst)
    {
       if (TempData["doc"] != null)
        {
            // Your code will be here
        }
    }
