    public IQueryable<ActivityRegister> GetRegisters(int activityID) 
    {
        var activityRegisters = ActivityDBContext.ActivityRegisters.Where(x => x.ActivityID == activityID x.IsActive == true).OrderBy(x => x.ActivityRegisterID).ToList();
		var roomIdsFromActivityRegisters = activityRegisters.Select(activityRegister => activityRegister.roomID);
        var rooms = AdminDBContext.Rooms.Where(room => roomsIdFromActivityRegisters.Contains(room.Id)).ToList();
        var resultFromJoinAcrossContexts = (from activityRegister in activityRegisters 
                                            join room in rooms on activityRegister.roomID equals room.Id
                                            select new ActivityRegister
                                            {
                                                Room = room,
                                                roomID = room.Id,
                                                Id = activityRegister
                                             });
        return resultFromJoinAcrossContexts.AsQueryable();
    }
