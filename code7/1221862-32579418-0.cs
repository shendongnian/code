    TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("http://tfsservername:8080/tfs/DefaultCollection"));
            ITestManagementTeamProject project = tfs.GetService<ITestManagementService>().GetTeamProject("teamprojectname");
            foreach (ITestRun tRun in project.TestRuns.ByBuild(new Uri(("vstfs:///Build/Build/531"))))
            {
                foreach (ITestCaseResult tr in tRun.QueryResults())
                {
                    Console.WriteLine(tr.TestCaseTitle.ToString() + ":" + tr.Outcome.ToString());
                }
            }
