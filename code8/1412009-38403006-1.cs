	using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Google.Apis.Auth.OAuth2;
	using Google.Apis.Services;
	using Google.Apis.Analytics.v3;
	using Newtonsoft.Json;
		.
		.
		.
	try
	{
		// Get active credential
		string credPath = _exePath + @"\Private-67917519b23f.json";
		var json = File.ReadAllText(credPath);
		var cr = JsonConvert.DeserializeObject<PersonalServiceAccountCred>(json); // "personal" service account credential
		
		// Create an explicit ServiceAccountCredential credential
		var xCred = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(cr.ClientEmail)
		{
			Scopes = new[] {
				AnalyticsService.Scope.AnalyticsManageUsersReadonly,
				AnalyticsService.Scope.AnalyticsReadonly
			}
		}.FromPrivateKey(cr.PrivateKey));
		// Create the service
		AnalyticsService service = new AnalyticsService(
			new BaseClientService.Initializer()
			{
				HttpClientInitializer = xCred,
			}
		);
		// some calls to Google API
		var act1 = service.Management.Accounts.List().Execute();
		var actSum = service.Management.AccountSummaries.List().Execute();
		var resp1 = service.Management.Profiles.List(actSum.Items[0].Id, actSum.Items[0].WebProperties[0].Id).Execute();
