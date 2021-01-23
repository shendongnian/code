    var newSequence = new Button
    {
        ToolTip = currentSequence,
        Background = Brushes.Transparent,
        BorderThickness = new Thickness(0),
        HorizontalAlignment = HorizontalAlignment.Stretch,
        HorizontalContentAlignment = HorizontalAlignment.Stretch,
        Content = Path.GetFileName(currentSequence),
        CommandParameter = currentSequence,
    };
    var mouseBinding = new MouseBinding();
    mouseBinding.Gesture = new MouseGesture(MouseAction.LeftDoubleClick);
    mouseBinding.Command = PlaylistLoadCommand;
    newSequence.InputBindings.Add(mouseBinding);
