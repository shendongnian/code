    if (IsPostBack)
    {
       if (CheckBoxList1.Items.Cast<ListItem>().Count(li => li.Selected) != 0 && 
           CheckBoxList2.Items.Cast<ListItem>().Count(i => i.Selected) != 0)
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
