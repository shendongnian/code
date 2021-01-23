                TfsConfigurationServer configurationServer =
                    TfsConfigurationServerFactory.GetConfigurationServer(tfsUri);
                ReadOnlyCollection<CatalogNode> collectionNodes = configurationServer.CatalogNode.QueryChildren(
                   new[] { CatalogResourceTypes.ProjectCollection },
                   false, CatalogQueryOptions.None);
                var collectionNode = collectionNodes.Single();
                // List the team project collections
    
                // Use the InstanceId property to get the team project collection
                Guid collectionId = new Guid(collectionNode.Resource.Properties["InstanceId"]);
                TfsTeamProjectCollection teamProjectCollection = configurationServer.GetTeamProjectCollection(collectionId);
                ITestManagementService testManagementService = teamProjectCollection.GetService<ITestManagementService>();
                ITestManagementTeamProject testProject = testManagementService.GetTeamProject(teamProjectName);
    
                ITestPlan testPlan = testProject.TestPlans.Find(investigateRelease1TestPlanId);
                foreach (MtmTestResultInfo result in testResults)
                {
                    var testPoints = testPlan.QueryTestPoints("SELECT * FROM TestPoint WHERE TestCaseID = '" + result.TestCaseId + "'");
                    var testPoint = testPoints.First();
                    testRun.AddTestPoint(testPoint, null);
                }
    
                testRun.DateStarted = dateStarted;
                testRun.DateCompleted = dateCompleted;
                TimeSpan timeTaken = dateCompleted - dateStarted;
                testRun.State = TestRunState.Completed;
                testRun.Save();
                //cannot add comment until after test run is saved
                testRun.Comment = "my comment"
    
                var tfsTestResults = testRun.QueryResults();
                foreach (MtmTestResultInfo result in testResults)
                {
                    ITestCaseResult tfsTestResult = tfsTestResults.Single(r => r.TestCaseId == result.TestCaseId);
                    tfsTestResult.DateStarted = result.DateStarted;
                    tfsTestResult.DateCompleted = result.DateCompleted;
                    tfsTestResult.Outcome = result.Outcome;
                    tfsTestResult.Comment = result.Comment;
                    tfsTestResult.ErrorMessage = result.ErrorMessage;
                    tfsTestResult.RunBy = testRun.Owner;
                    tfsTestResult.Duration = result.DateCompleted - result.DateStarted;
                    tfsTestResult.State=TestResultState.Completed;
    
                    tfsTestResult.Save();
                    testRun.Save();
                }
                
                testRun.Save();
