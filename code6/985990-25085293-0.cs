    BlogContext context = new BlogContext();
    public List<Comment> GetComments(int articleID) {
        return context.Comments.Where(p => p.ArticleID == articleID).ToList();
    }
    public void SaveComment(Comment comment) {
        context.Comments.Add(comment);
        context.SaveChanges();
    }
    [ValidateAntiForgeryToken()]
    public PartialViewResult _Submit(Comment comment) {  
        ViewBag.ArticleID = comment.ArticleID;
        if (ModelState.IsValid) {
            try {
                commentRepository.SaveComment(comment);
                ViewBag.Message = "Saving was succesful";
            }
            catch( Exception ex ) {
                ViewBag.Message = "An error occurred. Further information: " + ex.Message;
            }
        else {
            ViewBag.Message = "An error occurred. Data may be not valid.";
        }
        List<Comment> comments = commentRepository.GetComments(comment.ArticleID);
        return PartialView("_GetComment", comments);
    }
