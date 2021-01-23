    public void Add(QueueItem queueItem)
    {
        var entity = queueItem.ApiEntity;            
        var statistic = new Statistic
        {
            Ip = entity.Ip,
            Process = entity.ProcessId,
            //ApiId = entity.ApiId,
            Api = _context.Apis.Single(a => a.Id == entity.ApiId),
            Result = entity.Result,
            Error = entity.Error,
            Source = entity.Source,
            DateStamp = DateTime.UtcNow,
            //UserId = int.Parse(entity.ApiKey),
            User = _context.Users.Single(u => u.Id == int.Parse(entity.ApiKey)
        };
        _statisticRepository.Add(statistic);
        unitOfWork.Commit();
    }    
