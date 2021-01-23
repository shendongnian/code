    private bool _isSwiped;
    private void SwipeablePage_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        if (e.IsInertial && !_isSwiped)
        {
            var swipedDistance = e.Cumulative.Translation.X;
            if (Math.Abs(swipedDistance) <= 2) return;
            if (swipedDistance > 0)
            {
                // go to next page
                this.Frame.Navigate(typeof(Page2));
            }
            else
            {
                // do nothing 
            }
            _isSwiped = true;
        }
    }
