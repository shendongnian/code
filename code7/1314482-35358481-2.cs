public ActionResult Index(string answer, int questionId)
    {
        using (S3WEntities1 ent = new S3WEntities1())
        {
            afqList.Question = ent.Questions.Where(w => w.QuQuestionId == questionId).Select(s => s.QuQuestion).FirstOrDefault().ToString();
            afqList.Answers = ent.Answers.Where(w => w.AnsQuestionId == questionId).Select(s => s.AnsAnswer).ToList();
        }
        <strong>afqList.NextQuestion = string.Format("Question{0}", questionId + 1);</strong>
        return View(afqList);
    }</code></pre>
Now in the View:
@using (Html.BeginForm(<strong>afqList.NextQuestion</strong>, "ControllerName", "FormMethod.Post))
