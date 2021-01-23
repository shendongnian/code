    public ActionResult Details(String id)
    {
        MyRecordContext rc = new MyRecordContext();
        List<MyRecord> rl = rc.MyRecords.Where(x => x.RecordID == id).OrderBy(x => x.RecordName).ToList();
    
        return View(rl);
    }
