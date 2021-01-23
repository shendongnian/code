    var button = new Button
            {
                Name = "undo",
                FontFamily = new FontFamily("Segoe MDL2 Assets"),
                Content = "&#xE10E",
                Opacity = 100,
            };
    ToolTipService.SetToolTip(button, "Tooltip here");
    ToolTipService.SetPlacement(button, PlacementMode.Bottom);
    toolbar.Children.Add(button);
