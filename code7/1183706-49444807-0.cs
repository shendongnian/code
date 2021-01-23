    var tfsurl = new Uri("http://localhost:8080/tfs/<***projectname***>/");    
    var ttpc = new TfsTeamProjectCollection(tfsurl);
    var bhc = ttpc.GetClient<BuildHttpClient>();
    var builds = bhc.GetBuildsAsync("<***projectname***>").Result;
    var build = builds
        .Where(x => x != null && x.Definition.Name.Equals("***buildDefinitionName***>"))
        .OrderByDescending(y => y.LastChangedDate)
        .FirstOrDefault();
    
    bhc.QueueBuildAsync(build);
 
