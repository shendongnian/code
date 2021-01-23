    public ActionResult StartQiz()
    {        
        object quest=null;
        using (var question = new Quizdb()) 
        {    
          quest = (from q in question.Exams
                           where q.ExamType.StartsWith("C#")
                           select q).ToList();
        }
        return View(quest );
    } 
