    private static IEnumerable<QueuedReports> GetAllFutureReportsForUnit(string unit, int RptID, DateTime finalDate)
    {
        List<QueuedReports> listToReturn = new List<QueuedReports>();
        DateTime currentDate = DateTime.Now;
        while (currentDate <= finalDate)
        {
            currentDate = ReportSchedulerConstsAndUtils.GetNextDateForUnitReportAfter(unit, RptID, currentDate);
            if (currentDate == DateTime.MinValue)
                continue;
            var qr = GetSingleReportForUnit(unit, RptID, currentDate);
            listToReturn.Add(qr);
        }
        return listToReturn;
    }
