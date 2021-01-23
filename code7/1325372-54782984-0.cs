    var tapRecognizer = new TapGestureRecognizer();
    tapRecognizer.Tapped += async (s,e) => 
    {
	   ((View)s).IsEnabled = false; // or reference the view directly if you have access to it
	   await Navigation.PopToRootAsync();
	   ((View)s).IsEnabled = true;
    };
    theLabel.GestureRecognizers.Add(tapRecognizer);
