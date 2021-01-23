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
        //This is with the assumption that the parameter Newsub is attached to the context already. 
        //As in you got the sub from the context then changed it then passed it into UpdateSubject
        public void UpdateSubject(Subject Newsub)
        {
            Subject Oldsub = ctx.Subjects.FirstOrDefault(s => s.Subject_ID == Newsub.Subject_ID);
            if(Oldsub !=null)//FirstorDefault can return null
            {                
                Oldsub = Newsub;
                //If Newsub is not attached you have to set manually set each property.
                //i.e.Oldsub.Name = Newsub.Name;
                ctx.SaveChanges();
            }
        }
