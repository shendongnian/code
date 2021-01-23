       public ActionResult Delete(int BasicListID)
        {
            MyBasicListAppEntities db = new MyBasicListAppEntities();
            tblBasicList objDelete = db.tblBasicLists.Find(id);
            db.tblBasicLists.Remove(objDelete);//this can actually be simplified 
            return RedirectToAction("Home");
        }
