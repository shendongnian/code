    MetroThumb mt;
    loadPage(){
        radialSlider.Loaded += (s, e) => {
            mt = radialSlider.FindChild<MetroThumb>("HorizontalThumb");
        };
        radialSlider.PreviewMouseDown += md;
    }
    private void md(object sender, RoutedEventArgs e) {
        if (!mt.IsMouseOver) {
            e.Handled = true;
        }
    }
