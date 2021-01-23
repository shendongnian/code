    var AllStatus = RepositoryFactory.OrderStatusRepository.GetAll().AsEnumerable()
                   .ToDictionary(x=> x.Id, x=> x.Status);
    var AllUsers = RepositoryFactory.UserRepository.GetAll().AsEnumerable()
                  .ToDictionary(u => u.UserId, u=> u.UserName);
    var result = RepositoryFactory.OrderHistoryRepository.GetAll()
            .Select(v => new
            {
                PatientId = v.UserId ,
                UserName = AllUsers.ContainsKey(v.UserId) ? AllUsers[v.UserId] : null,
                Status = AllStatus.ContainsKey(v.StatusId) ? AllUsers[v.StatusId] : null,
                StatusDate = v.UpdatedDate,
                Amount = v.Amount  
            }) ;
