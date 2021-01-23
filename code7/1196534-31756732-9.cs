    var query= (from v in db.Views
                where  DbFunctions.DiffDays(v.ViewDate,DateTime.Now)<=14
                group v by new {v.PostID, v.ViewDate} into g
                let count=g.Count()
                orderby count descending
                select new{ Post_ID=g.Key.PostID, View_Date=count, Title= g.First().Post.PostTitle}
               ).Take(5);
               
