    using(var db = new Context())
    {
        var post = db.LogPosts.First(p => p.ID == postID);
        var reply = post.Replies.First(r => r.ID == replyID);
        var logReplies = db.Set<LogReply>();
        logReplies.Remove(reply);
        
        db.SaveChanges();
    }
