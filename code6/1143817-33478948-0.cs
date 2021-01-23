    public MotorcycleViewModel GetModelData(int commentId, int postId)
    {
        MotorcycleViewModel result =new MotorcycleViewModel();
        using (var context = new CommentDBContext())
        {
           var post = (from pst in context.Post where pst.ID == postId  select pst).FirstOrDefault();
           var comment = (from cmt in context.Comment where cmt.ID == commentId select cmt).FirstOrDefault();
           result.CommentPointer = comment;
           result.PostPointer = post;
           return result;
        }
    }
