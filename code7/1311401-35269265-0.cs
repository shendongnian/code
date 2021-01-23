         ITestCase testCaseCore = testManagementTeamProject.TestCases.Create(); 
         currentTestCase = new TestCase(testCaseCore, sourceTestCase.ITestSuiteBase, testPlan); 
         
         currentTestCase.ITestCase.Area = sourceTestCase.Area; 
         currentTestCase.ITestCase.Title = sourceTestCase.Title; 
         currentTestCase.ITestCase.Priority = (int)sourceTestCase.Priority; 
         currentTestCase.ITestCase.Actions.Clear(); 
         currentTestCase.ITestCase.Owner = testManagementTeamProject.TfsIdentityStore.FindByTeamFoundationId(sourceTestCase.TeamFoundationId); 
     
         currentTestCase.ITestCase.Flush(); 
         currentTestCase.ITestCase.Save(); 
