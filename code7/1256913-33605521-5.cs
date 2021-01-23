    public JsonResult GetPosts()
    {
        var ret = (from post in db.Posts.ToList()
                   orderby post.PostedDate descending)
                   select new
                   {
                       Message = post.Message,
                       PostedBy = post.PostedBy,
                       PostedByName = post.ApplicationUser.UserName,
                       PostedByAvatar = _GenerateAvatarUrlForUser(post.PostedBy),
                       PostedDate = post.PostedDate,
                       PostId = post.PostId,
                   });
    
        return Json(ret, JsonRequestBehavior.AllowGet);
    }
    private string _GenerateAvatarUrlForUser(int? userId)
    {
        if (!user.HasValue)
            return null;
        var avatarImage = db.Files.SingleOrDefault(s => s.ApplicationUserId == userId);
        if (avatarImage != null)
            return Url.Action("GetFileData", new { fileId = avatarImage.FileId });
 
        return null;
    }
