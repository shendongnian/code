    Grid _ImageGrid = new Grid();
    _ImageGrid = this.ImageGridGenerator.Build(Images);
    // Attach click events
    foreach (System.Windows.Controls.Button _ImageButton in _ImageGrid.Children)
    {
        _ImageButton.Click += btnImage_Click;
    }
    grdImages.Children.Add(_ImageGrid);
