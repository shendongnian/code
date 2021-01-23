    public void StepOne(int i)
    {
        readText(SteplistBox.Items[i].ToString());
    }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter != null)
        {
            if ((string)e.Parameter == "one")
            {
                StepOne(0);
            }
            else if ((string)e.Parameter == "two")
            {
                StepOne(1);
            }
        }
    }  
