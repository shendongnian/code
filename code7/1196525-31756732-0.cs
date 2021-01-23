    var query= (from v in db.Views
                join p in db.Posts on v.PostID equals p.Id
                where  DbFunctions.DiffDays(v.ViewDate,DateTime.Now)<=14
                group v by new {v.PostID, p.PostTitle, v.ViewDate} into g
                select new{ Post_ID=g.Key.PostID, View_Date=g.Count(), Title= g.Key.PostTitle}
               ).OrderByDescending(z => z.View_Date).Take(5);
