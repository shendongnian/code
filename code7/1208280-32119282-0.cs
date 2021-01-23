    public void OpenBuildSummary(string tfsServer, string tfsProjectName)
    {
          // TFS Connection
          TfsTeamProjectCollection tfsServer = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(tfsServer));
          IBuildServer buildServer = (IBuildServer)tfsServer.GetService(typeof(IBuildServer));
    
          // Getting the TeamFoundationBuild from DTE Services
          var dteService = Package.GetGlobalService(typeof(EnvDTE.DTE)) as EnvDTE.DTE;
          var tfBuild = (dteService.GetObject("Microsoft.VisualStudio.TeamFoundation.Build.VsTeamFoundationBuild") as VsTeamFoundationBuild);
    
          var vcs = tfsServer.GetService<VersionControlServer>();
          var teamProjects = vcs.GetTeamProjects(tfsProjectName);
          var builds = buildServer.QueryBuilds(tfsProjectName).Builds;
    
          // Open First Build Summary from the Query (for Testing Purposes)
          tfBuild.OpenBuild(builds[0].Uri);
    }
