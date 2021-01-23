        public override void ReloadTableData()
        {
            if (ItemsSource == null) return;
            var calendarList = new List<Model>(ItemsSource as List<ActivityModel>);
            List<IGrouping<DateTime, Model>> groupedCalendarList = calendarList.GroupBy(cl => cl.ScheduledStart.Value.Date).ToList();
            if (ItemsSource != null)
                GroupedCalendarList = new List<IGrouping<DateTime, Model>>(groupedCalendarList);
          
            base.ReloadTableData(); // Here we are
        }
