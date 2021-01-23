    if (IsPostBack)
    {
       if (!CheckBoxList1.Checked && !CheckBoxList2.Checked)
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
