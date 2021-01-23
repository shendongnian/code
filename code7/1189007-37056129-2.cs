    using System;
    using System.Collections.Generic;
    using Microsoft.TeamFoundation.Build.WebApi;
    using Microsoft.VisualStudio.Services.Client;
    static void GetBuildStatus()
    {
        var tfsUrl = "http://<tfs url>:<port>/tfs/<collectionname>";
        var buildClient = new BuildHttpClient(new Uri(tfsUrl), new VssAadCredential());
        var definitions = buildClient.GetDefinitionsAsync(project: "<projectmame>");
        var builds = buildClient.GetBuildsAsync("<projectname>";
        foreach (var build in builds.Result)
        {
            Console.WriteLine(String.Format("{0} - {1} - {2} - {3}", build.Definition.Name, build.Id.ToString(), build.Status.ToString(), build.StartTime.ToString()));
        }
    }
