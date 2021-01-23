    var languageIsEnglish = language == "English";
    var studentIdIsNotSet = Student_id == 0;
    var hasMoreThanOneSubject = subjectCount > 1;
    var hasProjects = projectCount > 0;
    
    if(languageIsEnglish && (studentIdIsNotSet || (hasMoreThanOneSubject  || hasProjects )))
    {
      someFunction();
    }
