    if (!string.IsNullOrEmpty( CheckBoxList1.SelectedValue) && !string.IsNullOrEmpty( CheckBoxList2.SelectedValue))
                   {
                      Bind();
                   }
        else 
        {
        if (string.IsNullOrEmpty( CheckBoxList1.SelectedValue))
           {
              LABEL1.Text = ("Please select at least one checkbox();
           }
           else if (string.IsNullOrEmpty( CheckBoxList2.SelectedValue))
           {
              LABEL2.Text = ("Please select at least one checkbox").ToString();
           }
        }
