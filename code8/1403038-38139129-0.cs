    OctopusServerEndpoint endPoint = new OctopusServerEndpoint(server, apiKey);
    OctopusRepository repo = new OctopusRepository(endPoint);
    DashboardResource dash = repo.Dashboards.GetDashboard();
    List<DashboardItemResource> items = dash.Items;
    DashboardItemResource item = new DashboardItemResource();
    List<DashboardProjectResource> projs = dash.Projects;
    var projID = projs.Find(x => x.Name == projectName).Id;
    item = items.Find(x => x.ProjectId == projID && x.IsCurrent == true);
