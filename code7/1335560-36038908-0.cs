    public void NavigateToSecond()
    {
        var conductor = this.Parent as IConductor;
        conductor.ActivateItem(new SecondViewModel());
    }
