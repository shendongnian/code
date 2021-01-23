    var SiteSegmentTable = (from module in db.Module.AsEnumerable()
                                        group module by module.SegmentID into a
                                        join segment in db.Segment.AsEnumerable() on a.FirstOrDefault().SegmentID equals segment.SegmentID
                                        join site in db.Site.AsEnumerable() on segment.SiteID equals site.SiteID
                                        select new Segment()
                                        {
                                            ModuleCount =  a.Count(),
                                            SegmentID = segment.SegmentID,
                                            SiteName = site.SiteName,
                                            SegmentName = segment.SegmentName,
                                            CreatedBy = segment.CreatedBy,
                                            ModifiedBy = segment.ModifiedBy,
                                            CreatedOn = segment.CreatedOn,
                                            LastModifiedOn = segment.LastModifiedOn
                                        }).ToList();
