    private void SlideOutAnimation_Completed(object sender, EventArgs e)
    {
        if (!this.dismissAll)
            (this.DataContext as HelpOverlayControlViewModel).DismissCommand.Execute(null);
        else
            (this.DataContext as HelpOverlayControlViewModel).DismissAllCommand.Execute(null);
    }
