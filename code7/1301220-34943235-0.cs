    TemplateSummary[] TransformTemplates(IEnumerable<Template> templates)
    {
    	return templates.Select(t => new TemplateSummary()
    	{
    		Id = t.Id,
    		TemplateName = t.TemplateName,
    		Content = t.Content,
    	}).ToArray();
    }
