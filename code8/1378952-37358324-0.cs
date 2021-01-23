     public App()
        {
            PlotModel plotModel = new PlotModel { PlotAreaBackground = OxyColors.LightYellow };
            plotModel.Series.Add(new FunctionSeries(Math.Sin, -10, 10, 0.1, "sin(x)"));
            // The root page of your application
            MainPage = new ContentPage {
                Content = new PlotView {
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.Fill,
                    Model = plotModel
                }
            };
        }
