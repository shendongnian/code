    [HttpPost]
    public ActionResult LoadData()
    {
        var draw = Request.Form.GetValues("draw").FirstOrDefault();
        var start = Request.Form.GetValues("start").FirstOrDefault();
        var length = Request.Form.GetValues("length").FirstOrDefault();
        //Find Order Column
        var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
        var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
        int pageSize = length != null? Convert.ToInt32(length) : 0;
        int skip = start != null ? Convert.ToInt32(start) : 0;
        int recordsTotal = 0;
        using (MyDatatableEntities dc = new MyDatatableEntities())
        {
            var v = (from a in dc.Customers select a);
            //SORT
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                v = v.OrderBy(sortColumn + " " + sortColumnDir);
            }
            recordsTotal = v.Count();
            var data = v.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
        }
    }
