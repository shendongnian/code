    var AllStatus = RepositoryFactory.OrderStatusRepository.GetAll().AsEnumerable()
                   .ToDictionary(x=> x.Id, x=> x.Status);
    var AllUsers = RepositoryFactory.UserRepository.GetAll().AsEnumerable()
                  .ToDictionary(u => u.UserId, u=> u.UserName);
    var result = RepositoryFactory.OrderHistoryRepository.GetAll()
            .Select(v => new
            {
                PatientId = v.UserId ,
                UserName = AllUsers.ContainsKey(u.UserId) ? AllUsers[u.UserId] : null,
                Status = AllStatus.ContainsKey(u.StatusId) ? AllUsers[u.StatusId] : null,
                StatusDate = v.UpdatedDate,
                Amount = v.Amount  
            }) ;
