    if(ModelState.IsValid){
     PerformProcessingOf(viewModel);
     //Redirect or whatever...
    }
    else
    return view(viewModel);
