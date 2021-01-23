    public void WaitForTextChange()
    {
        if (repo.Dom.TextObject.InnerText == "Wait")
        {
            Delay.Duration(30000); // Waits for 30 seconds
            WaitForTextChange();
        } else {
            // Continue with test
            Report.Info("State changed to 'Done'");
        }
    }
