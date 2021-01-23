    this.PropertyChanged += (o, e) =>
    {
        if (e.PropertyName == nameof(Tests))
        {
            HasTests = !Tests.Count.Equals(0);
        }
    };
