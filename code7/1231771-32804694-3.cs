    if (IsPostBack)
    {
       if (!CheckBoxList1.Items.Any(i => i.Selected) && !CheckBoxList2.Items.Any(j => j.Selected))
       {
          Bind();
       }
       else if (!CheckBoxList1.Checked)
       {
          LABEL1.Text = ("Please select at least one checkbox();
       }
       else if (!CheckBoxList2.Checked)
       {
          LABEL2.Text = ("Please select at least one checkbox").ToString();
       }
    }
