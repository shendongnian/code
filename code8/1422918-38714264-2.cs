    var ret = (from dr in defectRecordQuery
                join ft in filterQuery on dr.FilterID equals ft.FilterID
                join l in levelQuery on dr.LevelID equals l.LevelID
                join d in attachmentQuery on dr.DefectRecordID equals d.DefectRecordID into drd
                from g in drd.DefaultIfEmpty()
                group g by new { dr.Code, ft.FilterName } into gg
                select new DefectRecordViewModel
                {
                    DefectRecordCode = gg.Key.Code,
                    DefectAttachmentContent = gg.OrderByDescending(x => x.CreateDateTime).FirstOrDefault() == null? null: gg.OrderByDescending(x => x.CreateDateTime).FirstOrDefault().FileContent,
                    LookupFilterName = gg.Key.FilterName,
                }).ToList();
