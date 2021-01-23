	using (var db = new Context()) {
 		var post = db.LogPosts.First(p => p.ID == postID);
		var reply = post.Replies.First(r => r.ID == replyID);
		db.Entry(reply).State = System.Data.Entity.EntityState.Deleted;
    	db.SaveChanges();
	}
