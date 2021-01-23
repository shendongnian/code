    // Property with notify of change
    public int Foo
    {
        get { return this.foo; }
        set
        {
            this.foo = value;
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(this.Foo));
        }
    }
