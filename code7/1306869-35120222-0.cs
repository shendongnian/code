    var questions = new List<QuestionsBySection>();
    // create sql connection
    // execute command
    
    while (dataReader.Read())
    {
        string title = dataReader.GetString("title");
        string question = dataReader.GetString("qtext");
        
        QuestionsBySection qbs = questions.FirstOrDefault(x => x.SectionTitle.Equals(title , StringComparison.OrdinalIgnoreCase))
        if (qbs != null)
        {
            qbs.SecionQuestions.Add(question);
            continue;
        }
        
        qbs = new QuestionsBySection
        {
            SectionTitle = title,
            SecionQuestions = new List<string>{ question }
        }
        questions.Add(qbs);
    }
