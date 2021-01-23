    OverallSummary GetOverallSummaryAsync(BasicSurveyReportViewModel model);
    CompanyInfo GetCompanyInfoAsync(BasicSurveyReportViewModel model);
    public async Task<ActionResult> Print(BasicSurveyReportViewModel paramModel)
    {
      OverallSummary overallSummary =
        await GetOverallSummaryAsync(paramModel);
      CompanyInfo companyInfo =
        await GetCompanyInfoAsync(paramModel);
      ViewBag.OverallSummary = overallSummary;
      ViewBag.CompanyInfo = companyInfo;
      return View();
    }
