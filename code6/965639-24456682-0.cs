    public override string ToString()
    {
       if (this.IsMoment) {
          Contract.Assume(this.Start.HasValue);
          return this.Start.Value.ToString("g");
       }
       else
          return string.Format("{0:g} – {1:g}", this.Start, this.End));
    }
