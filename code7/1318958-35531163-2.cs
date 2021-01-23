        var builder = new ODataConventionModelBuilder();
	    builder.Namespace = "TeamService";
	    builder.EntitySet<Team>("Teams");
	    builder.EntityType<Team>().Collection
		    .Action("BulkAdd")
		    .CollectionParameter<Team>("NewTeams");
