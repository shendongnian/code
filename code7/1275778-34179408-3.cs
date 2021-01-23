    private ListCollectionView Context { get; }
    private void UIElement_OnManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
    {
        if (e.TotalManipulation.Translation.X < 5)
        {
            if (Context.CurrentPosition == 0)
                Context.MoveCurrentToLast();
            else
                Context.MoveCurrentToPrevious();
            e.Handled = true;
        }
        else if (e.TotalManipulation.Translation.X > 5)
        {
            if (Context.CurrentPosition == Context.Count)
                Context.MoveCurrentToFirst();
            else
                Context.MoveCurrentToNext();
            e.Handled = true;
        }
    }
