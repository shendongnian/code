    List<SomeObjects> uniqueWithMax = (from rec in lstObjects
                                        group rec by new { rec.Dep, rec.Comp } into grp
                                        select new SomeObjects
                                        {
                                            Dep = grp.Key.Dep,
                                            Comp = grp.Key.Comp,
                                            Progress = grp.Max(x => x.Progress)
                                        }).ToList();
