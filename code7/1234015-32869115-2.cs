    public ActionResult Edit(int id, EmployeeEditViewModel viewModel)
    {
       try
       {
        if (!ModelState.IsValid)
        {
            viewModel.SkillsList = _skillService.GetAll().ToList();
            return View(viewModel);
        }
        //here your mapper is not attaching the employee to the context
        //var employee = Mapper.Map<Employee>(viewModel);
        you can do this 
        var employee = _employeeService.GetById(viewModel.Id);
        // after that ... update what the user did from the view model except the id as the id won't change
        employee = Mapper.Map<Employee>(viewModel, employee);
        // I think that the mapping have another overload to map to a destination. you can set the setup for the mappnig in the startup to ignore updating Ids        
        UpdateSkills(viewModel.NewSkills);
        _employeeService.Update(employee);
        return RedirectToAction("Index");
    }
    catch(Exception e)
    {
        ModelState.AddModelError("", e.Message);
        viewModel.SkillsList = _skillService.GetAll().ToList();
        return View(viewModel);
    }
}
