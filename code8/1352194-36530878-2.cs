    public ActionResult Delete(int? i)
    {
         var st = Students.Find(c=>c.Id==i);
         Students.Remove(st);
         return View("Index",lst);
    }
