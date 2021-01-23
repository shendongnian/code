    var aux = _myRepository.GetAll();
    var processGames = aux.Select(item => new ProcessGamePersonDTO
    {
        IdProcessList = item.ProcessPersonList != null && item.ProcessPersonList.Any()
                ? item.ProcessPersonList.Select(x => x.Process.Id).ToList()
                : new List<int>(),
        IdGame = item.Game.Id,
        GameName = item.Game.Name
    }).ToList();
