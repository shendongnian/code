    public ActionResult UserStoryList1(Arrays your)
        {
            var USData = (from row in objUS.tablename
                          where (row.is_deleted == false)
                          select row);
            if (!string.IsNullOrEmpty(array[0]) && array.Length > 0)
                foreach (var item in array)
                {
                    USData = USData.Where(u => u.table.column.Contains(item));
                }
            return PartialView("action", USData);
        }
