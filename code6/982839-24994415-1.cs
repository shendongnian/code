        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DisplayDate")
            {
                BlackOutDates = new List<DateTime> { DisplayDate.Date.AddDays(randm.Next(1, 5)), DisplayDate.AddDays(randm.Next(1, 5)) };
            }
        }
        
