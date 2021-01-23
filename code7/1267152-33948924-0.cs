    public ActionResult Create(int? ProjectID)
    {
        CreateDropDownListForCreateOrEdit(ProjectID);
        UtilityDTO model = new UtilityDTO
        {
            Project_ID = ProjectID, // add this
            Est_Relocation_Expense = 0M
        };
        return View(model);
    }
