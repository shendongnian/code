           using(var ctx = new StradaDataReviewContext2())
            {
                values.ForEach(u => { u.Username = user; u.Changed = DateTime.Now; });
                var test = ctx.UOSChangeLog.AddRange(values);
                ctx.SaveChanges();
                return true;
            }
