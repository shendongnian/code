    [HttpGet]
    public ActionResult Verify(string id){
       using(var context = new DbContext())
       {
          var userRepo = new UserRepository(context); 
          //Department repository can be used over the same context.
          var departmentRepo = new DepartmentRepository(context);
          if(userRepo.verifyUser(id)){
             return View();
          }
       }
    }
