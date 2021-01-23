    List<CheckBox> cboxes = new List<CheckBox>();
    cboxes.Add(cb1);
    cboxes.Add(cb2);
    ...
    cboxes.Add(cbN);
    ...
    if(cboxes.Any(b => b.Checked))
    {
       ...
    }
