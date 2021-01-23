    public ActionResult AllStudents(IEnumerable<StudentRowViewModel> model)
    {
        var checked = model.Where(x => x.IsChecked).Select(x => x.StudentId).ToList();
        var items = db.ACD_UNI_STUDENTS.Where(x => checked.Contains(x.UNIQUE_ID));
    }
