    ScrollViewer scroolviewr;
            private void ScrollViewer_PointerEntered(object sender, PointerRoutedEventArgs e)
            {
                scroolviewr = (sender as ScrollViewer); 
                (sender as ScrollViewer).VerticalScrollMode = ScrollMode.Disabled;
            }
    private void PageLayoutGrid_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            e.Handled = true;
        }
    
        private void LayoutManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            scroolviewr.VerticalScrollMode = ScrollMode.Enabled;
            var velocities = e.Velocities.Linear;
            Double swipeLeftRight = velocities.X;
            Double swipeUpDown = velocities.Y;
            // A negative value means swiping to the left
            if (swipeLeftRight < 0)
            {
                navigateToNextPage();
            }
            // a positive value is a swipe to the right.
            else if (swipeLeftRight > 0)
            {
                navigateToPreviousPage();
            }
        }
    <Grid ManipulationMode="TranslateX" ManipulationDelta="Grid_ManipulationDelta" ManipulationCompleted="Grid_ManipulationCompleted">
    <ScrollViewer HorizontalScrollBarVisibility="Disabled" HorizontalScrollMode="Disabled" PointerEntered="ScrollViewer_PointerEntered">
    .....
    </ScrollViewer>
