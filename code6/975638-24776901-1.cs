    tbl_Employee ObjEmployee = new tbl_Employee();
    ObjEmployee.InjectFrom(Model);
    if (Model.Male)
    {
        ObjEmployee.Sex = "m";
    }
    else
    {
        ObjEmployee.Sex = "f";
    }
    ObjEmployee.Department_Id = Model.Dept_id;
    ObjEmployee.Salary = Convert.ToInt32(Model.Salary);
    this._Repo.Insert(ObjEmployee);
