    [HttpPost]
        public ActionResult AR(IList<string> array, IList<string> array, IList<string> array, IList<string> array, IList<string> array)
        {
            array[0] = array[0].ToString();
            array[0] = array[0].ToString();
            array[0] = array[0].ToString();
            array[0] = array[0].ToString();
            array[0] = array[0].ToString();
            int tempR = Convert.ToInt32(Session["ID"]);
            var USData = objUS.tableName.Where(u => u.colName == false);
            if (array.Count < 2 && array.Count < 2 && array.Count < 2 && array.Count < 2 && array.Count < 2)
            {
                function2(Convert.ToInt32(Session["ID"]));
            }
            if (array1.Count > 1)
                USData = USData.Where(u => array1.Contains(u.tableName.colName));
            if (array2.Count > 1)
                USData = USData.Where(u => array2.Contains(u.tablename.colName));
            if (array3.Count > 1)
                USData = USData.Where(u => array3.Contains(u.tablename.colName));
            if (array4.Count > 1)
                USData = USData.Where(u => array4.Contains(u.tablename.colname));
            if (array5.Count > 1)
                USData = USData.Where(u => array5.Contains(u.tablename.tablename.colName));
            if (tempR != 0)
            {
                if (tempR != 1)
                    USData = USData.Where(us => us.colName == tempR);
                else
                    USData = USData.Where(us => us.colName == null);
            }
            ViewBag.RecordCount = recordCount = USData.Count();
            return PartialView("functionName", USData);
        }
