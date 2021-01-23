    AnswerRowList MakeAnswer(string answerGridCorrect, string answerGridResponses)
    {
    	return new AnswerRowList()
    	{
    		AnswerRows = answerGridResponses.Zip(
    			answerGridCorrect == null ?
    				Enumerable.Repeat<bool?>(null, answerGridResponses.Length) :
    				answerGridCorrect.Select(x => new Nullable<bool>(x == '1')),
    			(r, c) => new AnswerRow()
    			{
    				Correct = c,
    				Response = r == '1'
    			}).ToList()
    	};
    }
