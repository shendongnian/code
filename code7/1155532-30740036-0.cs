	private static byte[] Render(string reportRenderFormat, string deviceInfo, string DisplayName, string ReportPath, bool Visible, ReportDataSourceCollection DataSources, string repMainContent, List<string[]> repSubContent, ReportParameter[] reportParam)
	{
		AppDomainSetup setup = new AppDomainSetup { ApplicationBase = Environment.CurrentDirectory, LoaderOptimization = LoaderOptimization.MultiDomainHost };
		setup.SetCompatibilitySwitches(new[] { "NetFx40_LegacySecurityPolicy" });
		AppDomain _casPolicyEnabledDomain = AppDomain.CreateDomain("Full Trust", null, setup);
		try
		{
			WebReportviewer.FullTrustReportviewer rvNextgenReport2 = (WebReportviewer.FullTrustReportviewer)_casPolicyEnabledDomain.CreateInstanceFromAndUnwrap(typeof(WebReportviewer.FullTrustReportviewer).Assembly.CodeBase, typeof(WebReportviewer.FullTrustReportviewer).FullName);
			rvNextgenReport2.Initialize(DisplayName, ReportPath, Visible, reportParam, reportRenderFormat, deviceInfo, repMainContent, repSubContent);
				
			foreach (ReportDataSource _ReportDataSource in DataSources)
			{
				rvNextgenReport2.AddDataSources(_ReportDataSource.Name, (DataTable)_ReportDataSource.Value);
			}
			   
			return rvNextgenReport2.Render(reportRenderFormat, deviceInfo);
		}
		finally
		{
			AppDomain.Unload(_casPolicyEnabledDomain);
		}
	}
