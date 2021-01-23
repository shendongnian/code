    ReportingViewModel viewModel = null;
    if (dropdown1 == "Name")
    {
        var Results = entities.Report(SomeInputParameter).ToList();
    
        viewModel = new ReportingViewModel { Reports = Results };
    }
    
    return View("ReportGenerator", viewModel);
