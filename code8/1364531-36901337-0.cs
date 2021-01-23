    public ActionResult Index()
    {
        List<string> listadesumas = new List<string>();
        var FakeDbTable = new List<string>() { "a.bc", "a.cde", "b.xyz" };
        foreach (var item in FakeDbTable.Select(v=> new { itemname = v })
                .GroupBy(l => l.itemname.Substring(0, 1)).AsEnumerable().Select(z =>new { GroupingValue= z.Key, Total=string.Format("count {0}",z.Count())}).OrderByDescending(a=>a.GroupingValue))
                 {
            listadesumas.Add(string.Format(" result item {0}",item));
                 }
        var grupos = new SelectList(listadesumas.ToList());
        ViewBag.Group = grupos;
        return View();
    }
