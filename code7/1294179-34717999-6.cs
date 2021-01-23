        private async void ShowPatientVisitsVsDays()
        {
            IsChartBeingPopulated = true;
            this.ChartSubTitle = "Requests Vs Days";
            this.SeriesTitle = "Days";
            new ChartBoundCollection().Clear();
            IsChartBeingPopulated = await ShowRequestsVsDaysAsync();//here we are waiting till the async method is finished.
        }
        private async Task<bool> ShowRequestsVsDaysAsync()
        {
           return await Task.Run(() =>
            {
                if (PatientVisits.Any())//replace Count with Any to avoid unwanted enumerations.
                {
                    var days = PatientVisits.Select(p => p.VisitDate.Value.Date).Distinct();
                    foreach (var i in days)
                    {
                        var dayVisitCount = PatientVisits.Count(p => p.VisitDate.Value.Date == i);
                        chartBoundCollection.Add(new PatientVisitVsXAxis() { XAxis = i.ToShortDateString(), NumberOfPatientVisits = dayVisitCount });
                    }
                }
                Thread.Sleep(5000);//this is for testing. Sleep the thread for 5secs. Now your busyIndicator must be visible for 5secs minimum.
                return false;//return false, so that we can use it to populate IsChartBeingPopulated 
            });
        }
