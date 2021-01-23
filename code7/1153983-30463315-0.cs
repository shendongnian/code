    public ActionResult Create(ChangeRequestViewModel viewModel)
    {
        if(ModelState.IsValid == false) return View(viewModel); 
        var changeRequest = new ChangeRequest();
        foreach(var testPlan in viewModel.TestPlans) {
             changeRequest.TestPlanChecklist.Add(new TestPlanChecklist { Value = testPlan }
        }
        // ...
    } 
