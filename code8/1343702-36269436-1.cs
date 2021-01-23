    private void InitScreens()
    {
        var screenshots = Screen.AllScreens.OrderBy(scrn => scrn.Bounds.Location.X).ThenBy(scrn => scrn.Bounds.Location.Y).Select(screen => new Screenshot(GetScreenImage(screen.Bounds), screen.DeviceName));
    
        App.Current.Dispatcher.InvokeAsync(delegate
        {
            // store current selections
            var currentSelections = SelectedScreenshots.ToArray();
            Screenshots.Clear();
    
            for (int i = 0; i < 3; i++)
            {
                Screenshots.Add(screenshots.ElementAt(i));
            }
            // select what was previously selected
            SelectedScreenshots = new ObservableCollection<Screenshot>(Screenshots
               .Where(s => currentSelections.Any(c => c.DeviceName == s.DeviceName)));
        });
    }
