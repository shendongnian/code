    public ActionResult FillDeptName()
    
            {
                UlrikenEntities db1 = new UlrikenModel.UlrikenEntities();
    
                ViewBag.list = new ControllerHelper().FetchListItems();        
    
                return View("ChildMenuOfSubMenu", ViewBag.list);
    
            }
    
            [HttpPost]
    
            [ValidateInput(false)]
    
            public ActionResult ChildMenuOfSubMenu(ChildMenu obj)
    
            {
    
                UlrikenEntities db = new UlrikenEntities();
    
                ulriken_tblChildMenu objchild = new ulriken_tblChildMenu();
    
                objchild.fkSubMenuID = obj.fkSubMenuID;
    
                objchild.ChildMenuName = obj.ChildManuName;
    
                objchild.cPageBody = obj.Name;
    
                db.ulriken_tblChildMenu.Add(objchild);
    
                db.SaveChanges();
                
                ViewBag.list = new ControllerHelper().FetchListItems();
    
                return View("ChildMenuOfSubMenu");
    
            }
