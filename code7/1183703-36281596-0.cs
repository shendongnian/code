    namespace AIT.DMF.Plugins.Resolver.VNextBuildResult
    {
        using Microsoft.TeamFoundation.Build.WebApi;
        using Microsoft.VisualStudio.Services.Client;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading.Tasks;
        internal class TfsBuildHelper
        {
            private readonly VssConnection connection;
     
            private readonly BuildHttpClient client;
    
            internal TfsBuildHelper(Uri tpcUrl)
            {
                this.connection = new VssConnection(tpcUrl, new VssClientCredentials(true));
                this.client = connection.GetClient<BuildHttpClient>();
            }
    
            /// <summary>
            /// Returns the build definitions for a specific team project.
            /// </summary>
            public async Task<IEnumerable<DefinitionReference>> GetBuildDefinitionsFromTeamProject(string teamProject)
            {
                return await this.client.GetDefinitionsAsync(project: teamProject, type: DefinitionType.Build);
            }
    
            /// <summary>
            /// Return build numbers for specific team project and build definition.
            /// </summary>
            public async Task<IEnumerable<string>> GetAvailableBuildNumbers(string teamProject, string buildDefinition)
            {
                var builds = await this.client.GetBuildsAsync(project: teamProject, type: DefinitionType.Build);
                return builds.Select(b => b.BuildNumber);
            }
        }
    }
