    public ActionResult Index(string answer, int questionId, int answerId)
    {
        using (S3WEntities1 ent = new S3WEntities1())
        {
            afqList.Question = ent.Questions.Where(w => w.QuQuestionId == questionId).Select(s => s.QuQuestion).FirstOrDefault().ToString();
            afqList.Answers = ent.Answers.Where(w => w.AnsQuestionId == answerId).Select(s => s.AnsAnswer).ToList();
        }
        return View(string.Format("View{0}_{1}", questionId, answerId), afqList);
    }
