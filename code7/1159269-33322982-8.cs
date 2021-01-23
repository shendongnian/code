    public MediaElementBehavior()
    {
    }
    protected override void OnAttached()
    {
        base.OnAttached();
            
        MediaElement player = (MediaElement)this.AssociatedObject;
        MediaElementViewModel viewModel = (MediaElementViewModel)this.AssociatedObject.DataContext;
        player.Dispatcher.Invoke(() =>
        {
            // backing up the player methods inside its view-model.
            if (viewModel.Play == null)
                viewModel.Play = player.Play;
            if (viewModel.Stop == null)
                viewModel.Stop = player.Stop;
            if (viewModel.Focus == null)
                viewModel.Focus = player.Focus;
        });
    }
    protected override void OnDetaching()
    {
        base.OnDetaching();
    }
