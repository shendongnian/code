    public Boolean EditSubject(int LinkID, int SubjectID, string dbUser )
        {
            int totalRowCount;
            using (var context = new CADWEntities())
            {
                //string dbuser = System.Web.HttpContext.Current.User.Identity.Name;
                var q = (from l in context.LinkAnalysis
                         join s in context.Subjects on l.LinkAnalysisId equals s.LinkAnalysisId
                         orderby s.LinkAnalysisId
                         where l.LinkAnalysisCreator == dbUser && s.SubjectId == SubjectID
                         select 0);
                totalRowCount = q.Count();
                if (totalRowCount == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
           }
        }
