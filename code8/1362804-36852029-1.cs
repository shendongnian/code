    class RandomHostnameSelector : IHostnameSelector
    {
        string IHostnameSelector.NextFrom(IList<string> options)
        {
            return options.RandomItem();
        }
    }
