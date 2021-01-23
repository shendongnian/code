    List<string> Questions = new List<string>();
    Questions.Add("What is your [u]name[/u]?");
    Questions.Add("[i]How[/i] old are you?");
    
    String searchTerm = "your name".ToLower();
    String[] searchPhrases =  searchTerm.Split(null);
    
    var matching = (from question in Questions
    			where searchPhrases.Any(searchPhrase => question.Contains(searchPhrase))
    			select question);
    			
