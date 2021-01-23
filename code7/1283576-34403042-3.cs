    List<string> errors = new List<string>();
    if(!IsValidA()) errors.Add("Fail on IsValidA");
    if(!IsValidB()) errors.Add("Fail on IsValidB");
    if(!IsValidC()) errors.Add("Fail on IsValidC");
    if(!IsValidD()) errors.Add("Fail on IsValidD");
    if(!IsValidE()) errors.Add("Fail on IsValidE");
    if(errors.Count > 0)
    {
        string message = string.Join(Environment.NewLine, errors.ToArray());
        MessageBox.Show("Validation errors found:" + Environment.NewLine + message);
    }
