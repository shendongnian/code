    public ActionResult Index()
        {
            var questions = db.tblStudent.ToList();
            questions.CodeSnippet = questions.CodeSnippet.Replace("<p>", "").Replace("</p>","").Replace("<P>","").Replace("</P>","");
            return View(questions);
        }
