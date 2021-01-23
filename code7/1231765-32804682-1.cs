    if (IsPostBack)
    {
        bool seleceted1 = CheckBoxList1.Items.Any(li => li.Selected); // it seems no cast needed
        bool seleceted2 = CheckBoxList2.Items.Any(li => li.Selected);
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
