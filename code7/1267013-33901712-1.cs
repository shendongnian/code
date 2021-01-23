    public actionresult MyModelIndex(int? id)
    {
    var mymodel = _context.MyModels.Include(u => u.Comments).singleordefault(u => u.Id == id)
    return View(mymodel);
    }
