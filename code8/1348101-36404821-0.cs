    public string Error { get { return string.Empty; } }
    public string this[string property]
    {
        get
        {
            var msg = new StringBuilder();
            switch(property)
            {
                case "Date":
                    if(Date <1930) msg.AppendLine("Date must be greater than 1930");
                    if(Date >1990) msg.AppendLine("Date must be less than 1990");
                    break;
                case "projjects":
                    if(projjects.Count <= 0) msg.AppendLine("projjects must contain atleast 1 item");
                    break;
            }
            return msg.ToString();
        }
    }`
