    if (ModelState.IsValid)
            {
                Tag tag = new tag{id=post.Tags.Id};
                db.Tag.Attach(tag);
                db.Tag.Add(tag);
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
