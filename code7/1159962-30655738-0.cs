    public HttpStatusCodeResult Create (FirstViewModel viewModel)
    {
      viewModel.SecondViewModel = new SecondViewModel();
      viewModel.SecondViewModel.month = 13;
      if (TryUpdateModel(viewModel)
      {
        return new HttpStatusCodeResult(200);
      }
      else
      {
        return new HttpStatusCodeResult(304);
      }
    }
