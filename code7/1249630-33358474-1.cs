    int count = moduleselect.Items.Count;
    string value = string.Empty;            
    for(int i = 0; i < count; i++)
    {
        if (moduleselect.Items[i].Selected)
        {
            value = moduleselect.Items[i].Value + ",";
        }
    }
    // Trim the last ,
    value = value.TrimEnd(',');
    // Insert here
