    var resultsWithEmtpyCampaigns = campaigns.GroupJoin(
                    results,
                    camp => camp.Id,
                    campResult => campResult.CampaignId,
                    (x, y) => y.Select(c => new ReportModel
                    {
                        CampaignId = y.FirstOrDefault().CampaignId,
                        CoregName = y.FirstOrDefault().CoregName,
                        TotalVisitors = y.FirstOrDefault().TotalVisitors,
                        TotalUsers = y.FirstOrDefault().TotalUsers,
                        TotalPaidUsers = y.FirstOrDefault().TotalPaidUsers,
                        TotalUserConversion = y.FirstOrDefault().TotalUserConversion,
                        TotalPaidUserConversion = y.FirstOrDefault().TotalPaidUserConversion,
                        ReportCountryList = y.FirstOrDefault().ReportCountryList
                    })
                         .DefaultIfEmpty(new ReportModel
                         {
                             CampaignId = x.Id,
                             CoregName = x.Name,
                             TotalVisitors = 0,
                             TotalUsers = 0,
                             TotalPaidUsers = 0,
                             TotalUserConversion = 0,
                             TotalPaidUserConversion = 0
                         }))
                    .SelectMany(g => g).ToList();
    
                return
                    resultsWithEmtpyCampaigns;
