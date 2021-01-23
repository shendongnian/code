    private static ToMembershipUser MembershipUser { get; set; }
    // GET: Dashboard/AccountUsers/Edit
    public ActionResult Edit()
    {
        if(MembershipUser == null)
            MembershipUser = Membership.GetUser(User.Identity.Name, true) as ToMembershipUser;
    }
    [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult UploadMedia(IEnumerable<HttpPostedFileBase> files, int id)
        {
            var images = new MediaController().Upload(files);
            if (images == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("File failed to upload.");
            }
            AccountUser accountUser = db.AccountUsers.Find(id);
            db.Entry(accountUser).State = EntityState.Modified;
            accountUser.UpdatedAt = TimeStamp.Now();
            accountUser.MediaID = images[0];
            db.SaveChanges();
            MembershipUser.Media = accountUser.Media;
            MembershipUser.MediaID = accountUser.MediaID;
            return Json(new { result = images[0] });
        }
        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        public JsonResult DeleteMedia(int id)
        {
            bool delete = new MediaController().Delete(id, 1);
            if (!delete)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error. Could not delete file.");
            }
            MembershipUser.Media = null;
            MembershipUser.MediaID = null;
   
            return Json("Success");
        }
