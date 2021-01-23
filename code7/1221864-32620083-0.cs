    using System.Linq;
    using System.Net;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.TeamFoundation.Build.Client;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.TestManagement.Client;
    using System.Configuration;
    using System;
    
    
    namespace TfsService
    {
        public class TfsServiceWrapper
        {
            public TfsTeamProjectCollection TeamProjectCollection { get; private set; }
            public string TeamProject { get; private set; }
            public string BuildName { get; private set; }
            public Uri TfsUri { get; private set; }
    
            public TfsServiceWrapper()
            {
                TfsUri = new Uri(ConfigurationManager.AppSettings["tfsUri"]);
                TeamProject = ConfigurationManager.AppSettings["teamProject"];
                BuildName = ConfigurationManager.AppSettings["buildName"];
                ConnectToTeamProjectCollection();
            }
    
            public TfsServiceWrapper(Uri tfsUri, string teamProject, string buildName)
            {
                TfsUri = tfsUri;
                TeamProject = teamProject;
                BuildName = buildName;
                ConnectToTeamProjectCollection();
            }
    
            private void ConnectToTeamProjectCollection()
            {
                TeamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(TfsUri);
                TeamProjectCollection.EnsureAuthenticated();
            }
    
            public IBuildDetail LatestBuildDetail
            {
                get
                {
                    var spec = BuildServer.CreateBuildDetailSpec(TeamProject, BuildName);
                    spec.MaxBuildsPerDefinition = 1;
                    spec.QueryOrder = BuildQueryOrder.FinishTimeDescending;
                    return BuildServer.QueryBuilds(spec).Builds.FirstOrDefault();
                }
            }
    
            public IBuildServer BuildServer
            {
                get
                {
                    return (IBuildServer)TeamProjectCollection.GetService(typeof(IBuildServer));
                }
            }
    
    
            public ITestManagementService TestManagementService
            {
                get
                {
                    return (ITestManagementService)TeamProjectCollection.GetService(typeof(ITestManagementService));
                }
            }
    
            public XDocument LatestTestResultFile
            {
                get
                {
                    var latestRun = TestManagementService.GetTeamProject(TeamProject).TestRuns.ByBuild(LatestBuildDetail.Uri).First(run => run.QueryResults().Any());
                    var resolver = new XmlUrlResolver {Credentials = CredentialCache.DefaultCredentials};
                    var settings = new XmlReaderSettings {XmlResolver = resolver};
                    var reader = XmlReader.Create(latestRun.Attachments[0].Uri.ToString(), settings);
                    return XDocument.Load(reader);
                }
            }
    
        }
    }
