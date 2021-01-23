    [HttpPost]
     public ActionResult Search(int? GroupId) { 
         List<Group> listResult = ListGroup.Where(m=>m.GroupID == GroupId).ToList();
         return View("Index", listResult);
     }
