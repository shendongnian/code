    var res = from cpr in db.CiscoPhoneReport
              join app in db.ApplicationSummary on cpr.PhoneReportID equals app.PhoneReportID
              where cpr.PhoneReportID == phoneReportID
              select new PhoneReport
              {
                  AppSummary = new AppSummary
                  {
                      // Mappings
                  },
                  CSQModel = (from model in db.CSQActivityReport
                              where model.PhoneReportId == phoneReportID
                              select new CSQModel
                              {
                                  // Mappings
                              }).ToList()
              }
You were right that you need the CSQModels to be some sort of collection, be it a List or even a basic ICollection of type CSQModel. You can write another sub query for the CallDistributionSummary as needed.
