        public JsonResult GetDetail(string modelTypeName, int id)
        {
            var type = Type.GetType("MyProject.WebApplication.Models.MyProjctContext." + modelTypeName);            
            
            //reflection way
            var model = Activator.CreateInstance(type);
            var result = (*find method return type*)type.GetMethod("Find", new Type[] { int }).Invoke(model, new object[] { id });
            //constraint way : with constraint being an interface or a base class that defines .Find(int)
            var result = ((*constraint*)Activator.CreateInstance(type)).Find(id);
            
        
            return Json(new
                {
                    data = result
                },
                JsonRequestBehavior.AllowGet);
        }
