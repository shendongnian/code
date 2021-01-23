    var barSeries = new BarSeries
                  {
                                Title = "Fruit in Cupboard",
                                ItemsSource = new[]
                                                  {
                                                      new KeyValuePair<string, int>("TOR", 10),
                                                      new KeyValuePair<string, int>("SOC", 15),
                                                      new KeyValuePair<string, int>("BOS", 18),
                                                      
                                                      new KeyValuePair<string, int>("NON", 11)
                                                  },
                                IndependentValueBinding = new Binding("Key"),
                                DependentValueBinding = new Binding("Value")
                            };
    
        myChart.Series.Add(barSeries);
