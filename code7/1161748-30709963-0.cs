    private void OnCurrentChanged(object sender, EventArgs e)
    {
        if (!_cancelTabChange)
        {
            //Update current tab property, if user did not cancel transition
            CurrentTab = (string)Tabs.CurrentItem;
        }
        else
        {
            //navigate back to current tab otherwise
            Dispatcher.BeginInvoke(new Action(() => 
            {
                Tabs.MoveCurrentTo(CurrentTab);
                TabControl.Focus();
            }));
        }
    }
