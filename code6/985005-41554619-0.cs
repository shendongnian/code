	public static void CreateCulture(string name, string cultureInfo, string regionInfo)
	{
		try {
			CultureAndRegionInfoBuilder.Unregister(name);
		} catch { }
		var cib = new CultureAndRegionInfoBuilder(name, CultureAndRegionModifiers.None);
		cib.LoadDataFromCultureInfo(new CultureInfo(cultureInfo));  // Populate the new CultureAndRegionInfoBuilder object with culture information.
		cib.LoadDataFromRegionInfo(new RegionInfo(regionInfo));   // Populate the new CultureAndRegionInfoBuilder object with region information.
		cib.Register();
	}
