    public int Selected { get; set; } = 1;
    ...
    private void SetZero()
    {
        Selected = 0;
    }
    ...
    private async void ShowValue()
    {
        Numbers tmp=Numbers.Zero;
        switch (Selected)
        {
            case 0: tmp = Numbers.Zero;
               break;
            case 1:tmp = Numbers.One;
               break;
            case 2:tmp = Numbers.Two;
               break;
        }
        var dialog = new MessageDialog(tmp.ToString());
        await dialog.ShowAsync();
    }
