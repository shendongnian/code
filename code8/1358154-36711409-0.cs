    // Fired by an ICommand Property
    public void Contributions_CommandExecute(object param)
    {
        var queryContributions = context.contributions.Where(c => c.member == Member);
        ContributionCollection = new ObservableCollection<contribution>(queryContributions);
    }
