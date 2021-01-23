    if (!string.IsNullOrEmpty(ItemDescription))
    {
        viewModel.PORequests = viewModel.PORequests.Where(x => x.POItems
            .Any(i => i.Description.Contains(ItemDescription)))
            .ToPagedList(pageNumber, 5);
    }
