	void CreatePageModel()
	{
		var localization = new Localization();
		var model = new FrameworkModel();
		...
		model.Page.Title = localization.LocalizeText(r => r.Home.Title);
		model.Page.Keywords = localization.LocalizeText(r => r.Home.Keywords);
		model.Page.Description = localization.LocalizeText(r => r.Home.Description);
		model.Page.RSS = localization.LocalizeText(r => r.Home.RSS);
		model.Page.Scripts.Header = localization.LocalizeText(r => r.Home.ScriptsHeader);
		model.Page.Scripts.Footer = localization.LocalizeText(r => r.Home.ScriptsFooter);
		model.Page.Body = localization.LocalizeText(r => r.Home.Body);
	}
