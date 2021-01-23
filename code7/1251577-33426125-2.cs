        List<UnansweredCallList> abc = new List<UnansweredCallList>(new UnansweredCallList[]
        {
            new UnansweredCallList() {PhoneNumber="123123" , AgentAnswerTime="null", CallTime="12:30:59"},
            new UnansweredCallList() {PhoneNumber="321321" , AgentAnswerTime="null" , CallTime="12:54:50"}
        });
        List<AnsweredCallsList> def = new List<AnsweredCallsList>(new AnsweredCallsList[]
        {
            new AnsweredCallsList() {PhoneNumber="123123" , AgentAnswerTime="10272015 12:31:00", CallTime="12:30:59"},
            new AnsweredCallsList() {PhoneNumber="321321" , AgentAnswerTime="null" , CallTime="12:54:50"}
        });
        IEnumerable<UnansweredCallList> result = abc.Except<UnansweredCallList>(def, new CallListComparer());
        Console.WriteLine(result.Count<UnansweredCallList>());
