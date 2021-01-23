    List<List<Match> matches = ...
    string player = "playerA";
    
    var coplayers = matches.SelectMany(x=>x.Participants.Any(p=>p.Name == player)) // get all participants where group contains participant.
           .Where(x=>x.Name != player)                                             // List co participants 
           .Distinct()                                                             // Distinct them
           .ToList(); 
