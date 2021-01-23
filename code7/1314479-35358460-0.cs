     public ActionResult Index(string answer, int x)
        {
            using (S3WEntities1 ent = new S3WEntities1())
            {
                afqList.Question = ent.Questions.Where(w => w.QuQuestionId == x).Select(s => s.QuQuestion).FirstOrDefault().ToString();
                afqList.Answers = ent.Answers.Where(w => w.AnsQuestionId == x).Select(s => s.AnsAnswer).ToList();
            }
    
            return View(afqList);
        }
