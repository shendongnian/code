    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.Framework.Client;
    using Microsoft.TeamFoundation.Framework.Common;
    using Microsoft.TeamFoundation.Server;
    using Microsoft.TeamFoundation.VersionControl.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    IIdentityManagementService identityManagementService = tpc.GetService<IIdentityManagementService>();
    TfsTeamProjectCollection tpc = GetTfsCollection();
    TeamFoundationIdentity identity = identityManagementService.ReadIdentity(IdentitySearchFactor.AccountName, @"Domain\username", MembershipQuery.None, ReadIdentityOptions.None);
    TfsTeamProjectCollection impersonatedTPC = new TfsTeamProjectCollection(new Uri(this._tfsUri, this._tfsCollectionName), identity.Descriptor);
    WorkItemStore impersonatedWIS = impersonatedTPC.GetService<WorkItemStore>();
    ProjectCollection impersonatedProjects = impersonatedWIS.Projects;
    foreach (Project p in impersonatedProjects)
    {
    	if (p.Name == "My Team Project")
    	{
    		NodeCollection areas = p.AreaRootNodes;
    		foreach (Node area in areas)
    		{
    			if (area.HasWorkItemWriteRightsRecursive)
    			{
    				//They do have rights
    			}
    		}
    	}
    }
