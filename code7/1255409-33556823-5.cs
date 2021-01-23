    public async Task<ActionResult> ActionName(string EmpParentGuid)
        {
            Guid IDtemp = new Guid(EmpParentGuid);
            EmployeesViewModel model = new EmployeesViewModel();
            Employees E = new Employees();
            E = await db.Employees .FindAsync(IDtemp);
            model.YourModelColumn1 = E.YourModelColumn1;
            model.YourModelColumn2 = E.YourModelColumn2;
            return PartialView("_YourPartialView", model);
        }
