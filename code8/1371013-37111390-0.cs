    this.AddWebpagePopup.RegisterPropertyChangedCallback(Popup.IsOpenProperty, (d, e) =>
    {
        if (!this.popup.IsOpen)
        {
            // change focus to something else
        }
    });
