      public partial class MainWindow : Window
        {
        private double _lastSliderValue;
    	public MainWindow()
    	{
    	    InitializeComponent();
            _lastSliderValue = 0.7;
    	}
    
    	private void Slider_ValueChanged(object sender,
    	    RoutedPropertyChangedEventArgs<double> e)
    	{
    	    // ... Get Slider reference.
    	    var slider = sender as Slider;
    	    // ... Get Value.
            if(slider.Value != 0.0)
    	      _lastSliderValue = slider.Value;
    	    // ... Set Window Title.
    	    this.Title = "Value: " + value.ToString("0.0") + "/" + slider.Maximum;
    	}
        
    private void btnMute_Click(object sender, RoutedEventArgs e)
    {
        if (slider.Value <= 0.0)
        {
            slider.Value = _lastSliderValue;
            btnMute.Content = "Mute";
        }
        else
        {
            slider.Value = 0.0;
            btnMute.Content = " UnMute";
        }
        }
     }
