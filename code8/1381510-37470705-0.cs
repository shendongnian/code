	// based on https://etoptanci.wordpress.com/2011/05/04/seeing-all-code-changes-for-a-work-item/
	private static void GetChangesForWorkItem()
	{
		var configurationServer = TfsConfigurationServerFactory.GetConfigurationServer(new Uri(@"http://myserver:8080/tfs"));
		var tpcService = configurationServer.GetService<ITeamProjectCollectionService>();
		var collectionNodes = configurationServer.CatalogNode.QueryChildren(
			   new[] { CatalogResourceTypes.ProjectCollection },
			   false, CatalogQueryOptions.None);
		var collectionNode = collectionNodes.First(x => x.Resource.DisplayName == "<collection name>");
		// Use the InstanceId property to get the team project collection
		Guid collectionId = new Guid(collectionNode.Resource.Properties["InstanceId"]);
		TfsTeamProjectCollection collection = configurationServer.GetTeamProjectCollection(collectionId);
		var vcs = collection.GetService<VersionControlServer>();
		var store = new WorkItemStore(collection);
		var workItems = new List<WorkItem>()
		{
			store.GetWorkItem(1123),
			store.GetWorkItem(1145),
		};
	
		var associatedChangesets = new List<Changeset>();
		foreach (var workItem in workItems)
		{
			foreach (var link in workItem.Links) 
			{
				if((link==null) || !(link is ExternalLink))
				continue;
			
				string externalLink = ((ExternalLink)link).LinkedArtifactUri;
				var artifact =LinkingUtilities.DecodeUri(externalLink);
			
				if (artifact.ArtifactType == "Changeset")
					associatedChangesets.Add(vcs.ArtifactProvider.GetChangeset(new Uri(externalLink)));
			}
		}
	
		Console.WriteLine(associatedChangesets.Select(x=>x.ChangesetId).OrderBy(x => x));
	}
