    public ActionResult Delete(int id)
    {
         tblBasicList todoItem = FindTodoItem(id); //with whatever method to get that todo item
         return View(todoItem);
    }
