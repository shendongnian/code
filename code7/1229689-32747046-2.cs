    using (var context = new CADWEntities())
            {
                  var ownerCheck = context.LinkAnalysis.Join(context.Subjects
            										   x => x.LinkId,
            										   y => y.LinkId,
            										   (x, y) => new {Analysis = x, Subjects = y})
            									  .Where(join => join.Analysis.LinkAnalysisCreator == dbUser)
            									  .Where(join => join.Subjects.Subjects == SubjectID);
            									  
                totalRowCount = ownercheck.Count();
                if (totalRowCount == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
    
            }
