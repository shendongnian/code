    [HttpPost]
    public ActionResult Index(List<Album> list)
    {
        var userId = ....; // get the ID of the current user
        IEnumerable<int> selected = list.Where(x => x.Checked).Select(x => x.Id);
        foreach(int id in selected)
        {
            db.Add(new UserAlbum() { UserId = userId, AlbumId = id });
        }
        db.SaveChanges();
        return RedirectToAction(...); // redirect to another view
    }
    
