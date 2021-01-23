            DateTime beginDate = new DateTime(2015, 9, 22);
            DateTime endDate = DateTime.Today;
            DateList = new List<DateTimeModel>();
            DateTimeModel model; 
            
            for (DateTime date = beginDate; date < endDate; date =     date.AddDays(1))
            {
                model = new DateTimeModel();
                model.PreviousDate = date.AddDays(-1);
                model.CurrentDate = date;
                model.NextDate = date.AddDays(1);
                DateList.Add(model);
            }
