    TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("http://tfs_server_here:8080/tfs/something_here"));
    ITestManagementService tcm = (ITestManagementService) tfs.GetService(typeof(ITestManagementService));
    ITestManagementTeamProject testManagementTeamProject = tcm.GetTeamProject("team_name_here");
    ICoverageAnalysisManager coverageAnalysisManager = testManagementTeamProject.CoverageAnalysisManager;
    IBuildCoverage[] queryBuildCoverage = coverageAnalysisManager.QueryBuildCoverage(build.Uri.ToString(), CoverageQueryFlags.Modules);
