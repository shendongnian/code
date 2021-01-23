    if (( App.ViewModel.Images != null ) &&
        ( App.ViewModel.Images.Any()))
    {
       var images = App.ViewModel
                       .Images.Where(b => b.ImageName.ToLower() == strVal1.ToLower())
                              .ToList();
    
       if (images.Any())
          DataContext = images;
    }
