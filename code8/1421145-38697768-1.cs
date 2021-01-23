    var tfsRun = _testPoint.Plan.CreateTestRun(false);
    
    tfsRun.DateStarted = DateTime.Now;
    tfsRun.AddTestPoint(_testPoint, _currentIdentity);
    tfsRun.DateCompleted = DateTime.Now;
    tfsRun.Save(); // so results object is created
    
    var result = tfsRun.QueryResults()[0];
    result.Owner = _currentIdentity;
    result.RunBy = _currentIdentity;
    result.State = TestResultState.Completed;
    result.DateStarted = DateTime.Now;
    result.Duration = new TimeSpan(0L);
    result.DateCompleted = DateTime.Now.AddMinutes(0.0);
    
    var iteration = result.CreateIteration(1);
    iteration.DateStarted = DateTime.Now;
    iteration.DateCompleted = DateTime.Now;
    iteration.Duration = new TimeSpan(0L);
    iteration.Comment = "Run from TFS Test Steps Editor by " + _currentIdentity.DisplayName;
    
    for (int actionIndex = 0; actionIndex < _testEditInfo.TestCase.Actions.Count; actionIndex++)
    {
        var testAction = _testEditInfo.TestCase.Actions[actionIndex];
        if (testAction is ISharedStepReference)
            continue;
    
        var userStep = _testEditInfo.SimpleSteps[actionIndex];
    
        var stepResult = iteration.CreateStepResult(testAction.Id);
        stepResult.ErrorMessage = String.Empty;
        stepResult.Outcome = userStep.Outcome;
    
        foreach (var attachmentPath in userStep.AttachmentPaths)
        {
            var attachment = stepResult.CreateAttachment(attachmentPath);
            stepResult.Attachments.Add(attachment);
        }
    
        iteration.Actions.Add(stepResult);
    }
    
    var overallOutcome = _testEditInfo.SimpleSteps.Any(s => s.Outcome != TestOutcome.Passed)
        ? TestOutcome.Failed
        : TestOutcome.Passed;
    
    iteration.Outcome = overallOutcome;
    
    result.Iterations.Add(iteration);
    
    result.Outcome = overallOutcome;
    result.Save(false);
