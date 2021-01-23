    Style closeButtonStyle = new Style(typeof(Button));
    closeButtonStyle.Setters.Add(new Setter(UIElement.IsEnabledProperty, false));
    closeButtonStyle.Setters.Add(new Setter(UIElement.OpacityProperty, 0.0));
    Style msgBoxStyle = new Style(typeof(MessageBox));        
    msgBoxStyle.Setters.Add(new Setter(WindowControl.CloseButtonStyleProperty, closeButtonStyle));
