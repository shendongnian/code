    int timesClicked = 42;
    
    private void Img_Click(sender object, eventargs e)
    {
        timesClicked--;
        UpdateLabel();
    }
    
    internal void UpdateLabel()
    {
        label.Caption = timesClicked.ToString();
    }
