    var query= (from v in db.Views
                join p in db.Posts on v.PostID equals p.Id
                where  DbFunctions.DiffDays(v.ViewDate,DateTime.Now)<=14
                group new{v,p} by new {v.PostID, p.PostTitle, v.ViewDate} into g
                let count=g.Count()
                orderby count descending
                select new{ Post_ID=g.Key.PostID, View_Date=count, Title= g.Key.PostTitle}
               ).Take(5);
