    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        SecondType secondType = db.SecondTypes.Find(id);
    
        foreach (var thirdType in secondType.ThirdTypes)
        {
            db.ThirdTypes.Remove(thirdType);
        }
        db.SecondTypes.Remove(secondType);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
