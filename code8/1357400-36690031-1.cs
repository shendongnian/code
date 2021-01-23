    (from d in db.ObjectCategories
                         join a in db.MatchingObjects
                            on d.Id equals a.ObjectCategoryId into grp3
                         join b in db.Unlocks
                            on d.Id equals b.ObjectCategoryId into grp1
                         from m in grp1.DefaultIfEmpty()
                         join c in db.Members 
                            on m.StudentId equals studentId into grp2
                         from n in grp2.DefaultIfEmpty()
                         where m.ObjectCategoryId == null
                         where n.Id == null
                         orderby d.Id).AsEnumerable()
    /* this is the correct one */
    join c in db.Members 
    on m.StudentId equals studentId into grp2
    /* the below was the original incorrect join clause*/
    join c in db.Members
    on m.StudentId equals c.Id into grp2
