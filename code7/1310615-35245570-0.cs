    public IEnumerable<SessionInfo> GetItemsByTimeSlotIdByPage(int timeSlotId, int codeCampId, int pageNumber, int pageSize)
    {
    	var items = repo.GetItems(codeCampId).Where(t => t.TimeSlotId == timeSlotId);
    
    	items.Select(s => { s.RegistrantCount = GetRegistrantCount(s.SessionId); return s; });
    
    	// this is the important part
    	var resultSet = items.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
    
    	foreach (var item in resultSet)
    	{
    		item.Speakers = speakerRepo.GetSpeakersForCollection(item.SessionId, item.CodeCampId);
    	}
    
    	return resultSet;
    }
