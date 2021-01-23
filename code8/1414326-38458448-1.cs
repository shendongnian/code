    var res = (from p in _context.Players
                group p by p.Value into grp
                select new
                {
                    Name = grp.Key,
                    Max = grp.Max(rec => rec.Value),
                    Min = grp.Min(rec => rec.Value)
                }).ToList();
