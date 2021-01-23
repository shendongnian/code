    static TfsTeamProjectCollection _tfs = TfsTeamProjectCollectionFactory
        .GetTeamProjectCollection("<tfsUri>")
    
    (...)
    
    static string GetCurrentIterationPath()
    {
        var css = _tfs.GetService<ICommonStructureService4>();
        var teamProjectName = "<teamProjectName>";
        var project = css.GetProjectFromName(teamProjectName);
        var teamName = "<teamName>";
        var teamSettingsStore = _tfs.GetService<TeamSettingsConfigurationService>();
        var settings = teamSettingsStore
            .GetTeamConfigurationsForUser(new[] { project.Uri })
            .Where(c => c.TeamName == teamName)
            .FirstOrDefault();
        if (settings == null)
        {
            var currentUser = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            throw new InvalidOperationException(
                $"User '{currentUser}' doesn't have access to '{teamName}' team project.");
        }
        return settings.TeamSettings.CurrentIterationPath;
    }
