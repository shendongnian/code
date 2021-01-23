    var list = (from p in ctx.Vizite
                let Programat = p.DataEnd != null && p.DataStart != null
                             && p.AngajatiVizite.Count > 0
                order by Programat, p.Data
                select new
                {
                    p.Id,
                    p.Numar,
                    p.Data,
                    p.DataStart,
                    p.DataEnd,
                    Programat
                }).ToList();
