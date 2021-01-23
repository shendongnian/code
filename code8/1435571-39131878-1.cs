    public async Task<ActionResult> Report(string reportId, string centreID)
    {
    //This is where I'm trying to get the variable from the textbox
    using (var client = this.CreatePowerBIClient())
    {
        var reportsResponse = await client.Reports.GetReportsAsync(this.workspaceCollection, this.workspaceId);
        var report = reportsResponse.Value.FirstOrDefault(r => r.Id == reportId);
        IEnumerable<string> roles = new List<string>() { "xxxxxxxx" };
         // I can hardcode the username here, and it works, but can't pass in a variable from the html like above
        var embedToken = PowerBIToken.CreateReportEmbedToken(this.workspaceCollection, this.workspaceId, report.Id, centreID, roles);
        var viewModel = new ReportViewModel
        {
            Report = report,
            AccessToken = embedToken.Generate(this.accessKey)
        };
        return View(viewModel);
    }
    }
    
