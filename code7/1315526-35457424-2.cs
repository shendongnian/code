	static IList<GrossPanel> BuildGrossPanelList(List<Panel> input, GrossPanel template)
	{
		var templatePanels = template.PanelList
    		.OrderBy(panel => panel.Width);
 
		var inputPanels = input
		    .OrderBy(panel => panel.Width)
		    .ThenBy(panel => panel.Id);        
		// If `input` can have elements with the same `panel.Width` 
		// and you want to always retun the same result then the sorting has to be extend.
		var templatesWithMatchingPanels = templatePanels
			.ToDictionary(
				tp => tp,
				tp => inputPanels.Where(p => p.Width == tp.Width).ToList());
 
		return GetGrossPanels(templatesWithMatchingPanels);
	}
	
	static IList<GrossPanel> GetGrossPanels(Dictionary<Panel, List<Panel>> templatesWithMatchingPanels)
	{
		var result = new List<GrossPanel>();
		while(CanCreateNewGrossPanel(templatesWithMatchingPanels))
		{
			result.Add(CreateNewGrossPanel(templatesWithMatchingPanels));
		}
		return result;
	}
	static bool CanCreateNewGrossPanel(Dictionary<Panel, List<Panel>> templatesWithMatchingPanels)
	{
		return templatesWithMatchingPanels.All(entry => entry.Value.Any());
	}
 
	static GrossPanel CreateNewGrossPanel(Dictionary<Panel, List<Panel>> templatesWithMatchingPanels)
	{
		var result = new GrossPanel();
		foreach(var templatePanelEntry in templatesWithMatchingPanels)
		{
			var firstMatchingPanel = GetAndRemoveFirst(templatePanelEntry.Value);
			result.AddNetPanel(firstMatchingPanel);
		}
		return result;
	}
 
	static Panel GetAndRemoveFirst(IList<Panel> panels)
	{
		var result = panels.First();
		panels.RemoveAt(0);
		return result;
	}
