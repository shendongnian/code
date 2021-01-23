    var userList = string.Join(",", Array.ConvertAll(request.Users, x => x.ToString()));
    List<UserModel> result = // move it outside foreach and pass userList to make database call.
    foreach (var resultList in result.GroupBy(x => x.UserId))
    {
        var perUserResults = resultList.ToList();
        UserRecord record = new UserRecord();
        record.UserId = resultList.Key; //key is the user id field since we have grouped on UserId
        record.TimePeriodList = new List<TimePeriod>();
        for (int i = 0; i < perUserResults.Count; i += 2)
        {
            TimePeriod timeData = new TimePeriod();
            timeData.StartTime = perUserResults[i].TimeDate;
            timeData.EndTime = perUserResults[i + 1].TimeDate;
            record.TimePeriodList.Add(timeData);
        }
    
        response.UserRecordList.Add(record);
    }
