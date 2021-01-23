    private void ScrollTable(int scrollcount, string pageDirection, string delay)
    {
        Actions actions = new Actions(DlkEnvironment.AutoDriver);
        for (int i = 1; i <= scrollcount; i++)
        {
            //if loading is not displayed/visible,
            IsLoadingScreenIsDisplayed(delay);
            //execute after waiting
            switch (pageDirection.ToLower())
            {
                case "up":
                    actions.KeyDown(Keys.PageUp).Perform();
                    break;
                case "down":
                    actions.KeyDown(Keys.PageDown).Perform();
                    break;
                default:
                    throw new Exception("Invalid direction");
            }
        }
        Thread.Sleep(1000);
    }
    
