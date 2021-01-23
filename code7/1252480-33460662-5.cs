    public ActionResult Index()
        {
            var questions = db.tblStudent.ToList();
            // Iterate through each item of the table
            foreach(var tmp in questions)
            {
                tmp.CodeSnippet = StripHTML(tmp.CodeSnippet);
            }
            return View(questions);
        }
