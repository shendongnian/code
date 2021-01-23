     var json = await GetCustomerAsync();
     var customers = JsonConvert.DeserializeObject<Customer[]>(json);
    
     dynamic seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };
    
     foreach (Customer c in customers) {
        seriesP1.Slices.Add(new PieSlice(c.CustomerName, c.SomeValue) { IsExploded = false, Fill = OxyColors.Teal });
     }
