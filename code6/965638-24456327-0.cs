    public override string ToString()
    {
        return (this.IsMoment 
            ? this.Start.Value.ToString("g") 
            : string.Format("{0:g} – {1:g}", this.Start, this.End));
    }
