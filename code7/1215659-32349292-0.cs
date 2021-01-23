    public void MySlider_ManipulationDelta(object sender, 
      ManipulationDeltaRoutedEventArgs e)
    {
        var velocities = e.Velocities
        var slider = sender as Slider;
        if(slider != null)
        {
            //Create a fomula based on the velocities to fit your needs.
        }
    }
