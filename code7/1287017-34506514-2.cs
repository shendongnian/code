    public async Task<ActionResult> Create([Bind(Include = "ArtistID,ArtistName")] Artist artist)
    {
        if (!ModelState.IsValid) return Json(new { success = false });
        db.Artists.Add(artist);
        var albums = await _albumService.GetAlbumsForArtist(artist.ArtistID);
        foreach (var album in albums)
        {
            db.Albums.Add(albums)
        }
        db.SaveChanges();
        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
    }
