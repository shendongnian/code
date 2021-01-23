    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append(Name)
          .Append(" ")
          .Append(Surname);
        return sb.ToString();
    }
