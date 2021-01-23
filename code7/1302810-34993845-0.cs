	Item enItem = Sitecore.Context.Database.GetItem(item.ID, Sitecore.Data.Managers.LanguageManager.GetLanguage("en"))
	if (enItem.Versions.Count == 0)
	{
		using (new LanguageSwitcher("en"))
		{
			enItem.Editing.BeginEdit();
			enItem.Versions.AddVersion();
			enItem.Editing.EndEdit();
		}
	}
