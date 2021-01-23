    public ActionResult GetDatas()
    {
        MainModel model = new MainModel();
        var list = new List<CheckboxModel>
        {
             new CheckboxModel{Id = 1, Name = "India", Checked = false},
             new CheckboxModel{Id = 2, Name = "US", Checked = false},
             new CheckboxModel{Id = 3, Name = "UK", Checked = false}
        };
        model.CheckBoxes = list;
        return View(model);
    }
