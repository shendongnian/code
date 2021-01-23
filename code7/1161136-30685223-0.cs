    //First we have lists of values (users) and senders
    List<string> values= new List<string>(){"John","Team"};
    List<string> senders = new List<string>(){"John","Team"};
    //Then we can join that list using string.join
    var allUsers = string.Join(",", values);
    var allSender = string.Join(",", senders);
    //Next we will be replacing it in our string
    var namedString = Regex.Replace(string, @"<<USER>>", allUsers);
    var output = Regex.Replace(namedString , @"<<SENDER>>", allSender);
