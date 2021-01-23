    public override string ToString()
    {  var builder = new StringBuilder();
       /// more lines here
       builder.Append(gallonCost.ToString("C"));
       builder.Append(" gallons\n\n");
       // etc
       return builder.ToString();
    }
