    if (ModelState.IsValid)
            {
                Tag tag = new tag{id='The tag id you get back posted from your form'};
                db.Tag.Attach(tag);
                db.Tag.Add(tag);
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
