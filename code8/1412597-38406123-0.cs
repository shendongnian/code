    private void Page2_Loaded(object sender, RoutedEventArgs e)
    {
        if (setting.Contains("save"))
        {
            //Initialize Points with the value from settings
            Points = int.Parse(setting["save"].ToString());
            PointsText.Text = Points.ToString();            
        }
    }
