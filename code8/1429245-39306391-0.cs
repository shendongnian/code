    Using System.ComponentModel;
    foreach (var item in arrToEmail) 
    {
        if (RegularExpressions.Regex.IsMatch(Strings.Trim(Sender), "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$")) 
        {
            msg.To.Add(new MailAddress(item));
        }
    }
    foreach (var item in arrCCEmail) 
    {
        if (RegularExpressions.Regex.IsMatch(Strings.Trim(Sender), "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$")) 
        {
            msg.CC.Add(new MailAddress(item));
        }
    }
