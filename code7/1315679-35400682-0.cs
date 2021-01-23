    var userList = string.Join(",", Array.ConvertAll(request.Users, x => x.ToString()));
    List<UserModel> result = // move it outside foreach and pass userList to make database call.
    var users = result.GroupBy(x => x.UserId);
    foreach (var user in users) // request.Users is a Array of UserId's 
    {
        UserRecord record = new UserRecord();
        record.UserId = user; //whatever that is
        record.TimePeriodList = new List<TimePeriod>();
        for (int i = 0; i < result.Count; i += 2)
        {
            TimePeriod timeData = new TimePeriod();
            timeData.StartTime = result[i].TimeDate;
            timeData.EndTime = result[i + 1].TimeDate;
            record.TimePeriodList.Add(timeData);
            }
            response.UserRecordList.Add(record);
    }
