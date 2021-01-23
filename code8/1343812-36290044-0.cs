    var eventId = "307";
    var startTime = System.DateTime.Now.AddMinutes(-10);
    var endTime = System.DateTime.Now;
    
    var query = string.Format(@"*[System/EventID={0}] and *[System[TimeCreated[@SystemTime >= '{1}']]] and *[System[TimeCreated[@SystemTime <= '{2}']]]",
        eventId, 
        startTime.ToUniversalTime().ToString("o"),
        endTime.ToUniversalTime().ToString("o"));
