    public override string Quack()
    {
        Contract.Requires(!this.Battery.IsEmpty);
        return "electric quack";
    }
