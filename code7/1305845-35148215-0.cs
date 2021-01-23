    Id(x => x.WorkflowArtifactIdentifier).GeneratedBy.Assigned();
    
    HasMany(x => x.RestrictedSystemUsageIds)
    	.Element("RestrictedSystemUsageId")
    	.KeyColumn("WorkflowArtifactIdentifier")
    	.Table("RestrictedSystemUsageForWorkflow")
    	.AsSet();
