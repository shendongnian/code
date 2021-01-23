    public ActionResult GetAvatar(int id) {
        using (var dbContainer = new MainDBContainer()) {
            return File(dbContainer.UserSet.First(p => p.Id == id).Image.Image,"image/png");
        }
    }
