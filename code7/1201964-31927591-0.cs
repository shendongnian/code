       for (int i=0; i<checkboxlist1.Items.Count; i++)
       {
             if (checkboxlist1.Items[i].Selected)
             {
                   Message.Text += checkboxlist1.Items[i].Text + "<br />";
              }
       }
