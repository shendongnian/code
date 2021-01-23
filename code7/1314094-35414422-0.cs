        private void MenuItemCallback(object sender, EventArgs e)
        {
            var context = (ITeamFoundationContextManager)ServiceProvider.GetService(typeof(ITeamFoundationContextManager));
            IBuildServer buildServer = context.CurrentContext.TeamProjectCollection.GetService<IBuildServer>();
            var teamExplorer = (ITeamExplorer)ServiceProvider.GetService(typeof(ITeamExplorer));
            var buildsPageExt = (IBuildsPageExt)teamExplorer.CurrentPage.GetExtensibilityService(typeof(IBuildsPageExt));
            var menuCommand = (MenuCommand)sender;
            if (menuCommand.CommandID.Guid == CommandSetCompleted)
            {
                foreach (var buildDetail in buildsPageExt.SelectedBuilds)
                    Process.Start("explorer.exe", GetBuild(buildServer, buildDetail).DropLocation);
            }
            if (menuCommand.CommandID.Guid == CommandSetFavorite)
            {
                var definitions = buildsPageExt.SelectedFavoriteDefinitions.Concat(buildsPageExt.SelectedXamlDefinitions).ToArray();
                foreach (var build in GetLatestSuccessfulBuild(buildServer, definitions))
                    Process.Start("explorer.exe", build.DropLocation);
            }
        }
        private IBuildDetail GetBuild(IBuildServer buildServer, IBuildModel buildModel)
        {
            Uri buildUri = new Uri(buildModel.GetType().GetProperty("UriToOpen").GetValue(buildModel).ToString());
            return buildServer.GetBuild(buildUri);
        }
        private IBuildDetail[] GetLatestSuccessfulBuild(IBuildServer buildServer, IDefinitionModel[] buildDefinitions)
        {
            var spec = buildServer.CreateBuildDetailSpec(buildDefinitions.Select(bd => bd.Uri));
            spec.MaxBuildsPerDefinition = 1;
            spec.QueryOrder = BuildQueryOrder.FinishTimeDescending;
            spec.Status = BuildStatus.Succeeded;
            var builds = buildServer.QueryBuilds(spec);
            return builds.Builds;
        }
