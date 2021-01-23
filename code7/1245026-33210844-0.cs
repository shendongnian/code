    public findEmployerById(int id){
    return db.MyModel.Where(a => a.EmployeID == id);
    }
    public ActionResult Index(int id)
    {
       return View(new EmployerModel().findEmployerById(id));
    } 
