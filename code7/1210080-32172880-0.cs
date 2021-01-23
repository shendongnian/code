    //Create new base entry
    BASE_ID base = new BASE_ID();
  
    POSTS post = new POSTS() {Thread = new THREADS()};
    base.Posts.Add(post);
    base.User = new USERS();
    oEntity.BASE_ID.Add(base);
    oEntity.SaveChanges(); 
