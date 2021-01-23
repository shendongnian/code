    var result = from usr in _userService.GetAllUsers()
                    join tr in _trainingService.GetAllTrainings() on usr.userID equals tr.userID into
                        usersInTraining
                    join usrTr in _eventService.GetAllEvents() on usr.userID equals
                        usrTr.userID into usersInEvents 
                 select new { Username = usr.Username, EventName = usrTr.EventName /* Select other values here */ };
    if(result.Any()) {
        for(int i = 0; i < result.Count; i++) {
            Debug.WriteLine("User: {0} / Event {1}", result[i].Username, result[i].EventName);
        }
    }
