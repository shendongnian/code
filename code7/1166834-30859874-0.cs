    var res = db.bibleContext.Where(x => x.Book == bookF && x.Chapter == chapterF && x.Verse == verseF).FirstOrDefault();
            res.favoriteverse = i;
            db.bibleContext.Attach(res);
            db.Entry(res).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
    
