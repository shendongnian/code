    public ActionResult Index()
        {
            var questions = db.tblStudent.ToList();
            // Iterate through each item of the table
            foreach(var tmp in questions)
            {
                tmp.CodeSnippet = tmp.CodeSnippet.Replace("<p>", "").Replace("</p>","").Replace("<P>","").Replace("</P>","");
            }
            return View(questions);
        }
