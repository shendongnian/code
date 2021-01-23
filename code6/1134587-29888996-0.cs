    var video = db.Videos.SingleOrDefault(c => c.Link.Equals(link));
    if(video == null)
    {
        video = new Video { ... };
        db.Videos.Add(video);
        db.SaveChanges();
        var course = db.Courses.Include("Videos").Single(c => c.ID == courseID);
        course.Videos.Add(video);
        db.SaveChanges();
    }
