    if (IsPostBack)
    {
        bool seleceted1 = CheckBoxList1.Items.Cast<ListItem>().Any(li => li.Selected);
        bool seleceted2 = CheckBoxList2.Items.Cast<ListItem>().Any(li => li.Selected);
        if (selected1 && selected2)
        {
           Bind();
        }
        else if (!selected1)
        {
           LABEL1.Text = ("Please select at least one checkbox();
        }
        else if (!selected2)
        {
           LABEL2.Text = ("Please select at least one checkbox").ToString();
        }
