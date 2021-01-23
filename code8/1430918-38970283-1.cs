    protected override void OnPreviewKeyDown( KeyEventArgs e )
    {
        if (!Editing)
        {
            if ( e.Key == Key.Left )
            {
                ((Entry)(EntryView.SelectedItem)).GetNextLeft().IsSelected = true;
                e.Handled = true;
            }
            else if ( e.Key == Key.Right )
            {
                ((Entry)(EntryView.SelectedItem)).GetNextRight().IsSelected = true;                
                e.Handled = true;
            }
            else if ( e.Key == Key.Up )
            {
                ((Entry)(EntryView.SelectedItem)).GetNextUp().IsSelected = true;
                e.Handled = true;
            }
            else if ( e.Key == Key.Down )
            {
                ((Entry)(EntryView.SelectedItem)).GetNextDown().IsSelected = true;
                e.Handled = true;
            }
            else if ( e.Key == Key.Tab || e.Key == Key.Enter || e.Key == Key.Space )
            {
                 //Nothing here seems to work.
                e.Handled = true;
            }
        }
    }
