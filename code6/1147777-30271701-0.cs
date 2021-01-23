        public List<Subject> GetAllSubjects()
        {
            List<Subject> sublist = ctx.Subjects.ToList();
            return sublist;
        }
        public void DeleteSubject(int SubjectID)
        {
            Subject sub = ctx.Subjects.FirstOrDefault(s => s.Subject_ID == SubjectID);
            if(sub!=null)//FirstorDefault can return null
            {
               ctx.Subjects.Remove(sub);
               ctx.SaveChanges();
            }
        }
