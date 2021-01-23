    foreach (var item in display)
    { 
          var viewModel = new PageListViewModel
          {
          PageTitle = item.Name
          };
        
          List<PageListViewModel> viewModelList = new List<PageListViewModel>();
          viewModelList.Add(viewModel);
          return View(viewModelList);
    }
