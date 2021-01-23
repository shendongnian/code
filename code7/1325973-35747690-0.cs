    var configrefs = from c in (
                from e in db.Metrics
                join j in db.ProgramLink on e.ProjectRef equals j.LinkedProject
                where (j.ProjectRef == id) && e.PartitNo == partit                    
                select new
                {
                    FieldName = e.FieldName,
                    FieldContents = e.MetricValue,
                    ProjectRef = e.ProjectRef,
                }).ToArray();
    return configrefs.ToPivotArray(
                                    i => i.FieldName, 
                                    i => i.ProjectRef,
                                    items => items.Any() ? items.FirstOrDefault().FieldContents : null);
