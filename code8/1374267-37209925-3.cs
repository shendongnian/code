    // note that we're caching our reference to IAudio;
    // I don't know whether it's a singleton or not
    var audioService = DependencyService.Get<IAudio>(); 
    TimeSpan timeSpan = audioService.GetInfo();
    Label lblDuration = new Label { Text = String.Format("{0:hh\\:mm\\:ss}", timeSpan) };
    var slider = new Slider {
        Minimum = 0,
        Maximum = timeSpan.TotalSeconds,
    };
    audioService.PositionChanged += (s, e) => {
        slider.Value = e.Position;
        label.Text = String.Format("Slider value is {0}", e.Position);
    }
