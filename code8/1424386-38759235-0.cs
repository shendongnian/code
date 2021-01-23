        public bool ChildRecords(CheckListTemplate questList)
        {
            int templateId = questList.Id;
            if (templateId > 0 && questList.Questions.Count() > 0)
            {
                var template = DBContext.CheckListTemplates.Include(p => p.Questions).SingleOrDefault(p => p.Id == templateId);
                template.Name = questList.Name;
                List<int> delQuestions = new List<int>();
                foreach(CheckListQuestion q in template.Questions)
                {
                    var question = questList.Questions.Where(x => x.Id == q.Id).FirstOrDefault();
                    if (question == null)
                       delQuestions.Add(q.Id);
                    else
                    {
                        q.Question = question.Question;
                        q.Clause = question.Clause;
                    }
                }
                if(delQuestions.Count()>0)
                   DBContext.CheckListTemplates.RemoveRange(DBContext.CheckListTemplates.Where(x => ids.Contains(x.Id)));
                DBContext.Entry(template).State = EntityState.Modified;
                DBContext.SaveChanges();
             }
         }
