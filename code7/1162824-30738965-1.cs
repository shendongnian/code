    for (int i = 0; i < checklist.Items.Count; i++)
    {
        if (checkist.Items[i].Selected)
        {
            checklist.Items[i].Attributes.CssStyle.Add("color", "red");         
        }
    }
