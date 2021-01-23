    var tempModels = _dataContext
        .Menus
        .Select(menu => new
        {
            childrenIds = menu.Childs.Select(item => item.Id).ToArray(),
            viewModel =
                new MenuViewModel
                {
                    Id = menu.Id,
                    Title = menu.Title
                }
        })
        .ToDictionary(
            keySelector: item => item.viewModel.Id);
    var viewModels = tempModels
        .Select(kv =>
            {
                var viewModel = kv.Value.viewModel;
                viewModel.Childs = kv
                    .Value
                    .childrenIds
                    .Select(childId => 
                        tempModels[childId].viewModel)
                    .ToList();
                return viewModel;
            })
        .ToList();
