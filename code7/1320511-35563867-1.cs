    public Exam FindExamFromAnything(object input)
    {
        int examID = 0;
        if (int.TryParse(input.ToString(), out examID))
        {
            return GetExamFromID(examID);
        }
        else
        {
            return GetExamFromName(input.ToString());
        }
        
    }
    
    
    public Exam GetExamFromID(int ID)
    {
        // get the Exam with the right ID from a database or something
    }
    
    public Exam GetExamFromName(string examName)
    {
        // get the Exam with the right name from a database
    }
