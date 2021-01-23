    public JsonResult GetPosts()
    {
        var ret = (from post in db.Posts
                   orderby post.PostedDate descending
                   select new
                   {
                       Message = post.Message,
                       PostedBy = post.PostedBy,
                       PostedByName = post.ApplicationUser.UserName,
                       PostedByAvatar = "",
                       PostedDate = post.PostedDate,
                       PostId = post.PostId,
                   });
    
        // fill the url
        foreach (var item in ret)
        {
            var avatarImage = db.Files.SingleOrDefault(s => s.ApplicationUserId == item.PostedBy);
            if (avatarImage != null)
                item.PostedByAvatar = Url.Action("GetFileData", new { fileId = avatarImage.FileId });
        }
    
        return Json(ret, JsonRequestBehavior.AllowGet);
    }
