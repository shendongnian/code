    private SelectList GetExamList()
    {
        return db.Exams
          .Select(e => new SelectListItem {
             Value = e.Id, 
             Text = e.Course.Name })
         .ToList();
    }
