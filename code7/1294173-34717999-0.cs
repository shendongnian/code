        private async void ShowPatientVisitsVsDays()
        {
            IsChartBeingPopulated = true;
            this.ChartSubTitle = "Requests Vs Days";
            this.SeriesTitle = "Days";
            new ChartBoundCollection().Clear();
            IsChartBeingPopulated = await ShowRequestsVsDaysAsync();
        }
        private async Task<bool> ShowRequestsVsDaysAsync()
        {
           return await Task.Run(() =>
            {
                if (PatientVisits.Any())
                {
                    var days = PatientVisits.Select(p => p.VisitDate.Value.Date).Distinct();
                    foreach (var i in days)
                    {
                        var dayVisitCount = PatientVisits.Count(p => p.VisitDate.Value.Date == i);
                        chartBoundCollection.Add(new PatientVisitVsXAxis() { XAxis = i.ToShortDateString(), NumberOfPatientVisits = dayVisitCount });
                    }
                }
                return false;
            });
        }
