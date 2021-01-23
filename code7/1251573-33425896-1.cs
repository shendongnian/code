    List<Call> unanswered = new List<Call>()
    {
    	new Call() { PhoneNumber = "123123", AgentAnswerTime = "null", CallTime = "12:30:59" },
    	new Call() { PhoneNumber = "321321", AgentAnswerTime = "null", CallTime = "12:54:50" }
    };
    
    List<Call> answered = new List<Call>()
    {
    	new Call() { PhoneNumber = "123123", AgentAnswerTime = "10272015 12:31:00", CallTime = "12:30:59" },
    	new Call() { PhoneNumber = "321321", AgentAnswerTime = "null", CallTime = "12:54:50" }
    };
    
    var result = unanswered.Where(call =>
    {
    	var answeredCall = answered.FirstOrDefault(c => c.PhoneNumber == call.PhoneNumber);
    
    	return answeredCall != null && answeredCall.AgentAnswerTime == "null";
    });
    
    foreach(var r in result)
    {
    	Console.WriteLine(r.PhoneNumber);
    }
