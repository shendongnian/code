     TableCell commentCell = new TableCell();
     Label lblComment = new Label();
     lblComment.Text = "Text to remain in the cell."
     commentCell.Controls.Add(lblComment);
     Button btnactiv = new Button();
     btnactiv.ID = y.ToString();
     btnactiv.Text = "Dept " + dr_depts["code_dept"].ToString() + "(" + nbr + " )";
     commentCell.Controls.Add(btnactiv);
