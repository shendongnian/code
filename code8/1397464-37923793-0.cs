    if (clickedLabel != null)
    {
        var Index = Convert.ToInt32(clickedLabel.Tag);
        clickedLabel.Image = icons[Index];
        //Check first clicked
        if (firstClicked == null)
        {
            firstClicked = clickedLabel;
            return;
        }
        secondClicked = clickedLabel;
        SetTimer();
    }
    private static void SetTimer ()
        {
            //System.Timers.Timer aTimer; at the beginning of your class
            aTimer = new System.Timers.Timer (2000); //the time you want in milliseconds
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }
