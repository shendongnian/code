    var objlist=( form a in contex.user
                 from b into contex.UserDetails.where(x=>x.Uid==a.id).
                  join b in contex.UserDetails on a.id equals a.Uid into gj
                  from subpet in gj.DefaultIfEmpty()
                            select new { Id=a.id, Name=a.name, Age=a.age, Height =subpet.Height,Eyes=subpet.Eyes, Hair=subpet.Hair}).ToList();
