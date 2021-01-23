    Table table = null;
    
    string BranchName = null;
    
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        TableRow tr;
        if (BranchName != dt.Rows[0]["Category"].ToString())
        {
            BranchName = dt.Rows[0]["Category"].ToString();
            // setup pane
            pane = new AccordionPane();
            // add pane to accordion
            acrDynamic.Panes.Add(pane);
    
            // pane content
            lbTitle = new Label();
            pane.ID = "Pane_" + BranchName;
            lbTitle.Text = BranchName;
            pane.HeaderContainer.Controls.Add(lbTitle);
    
            // pane container will have the table
            table = new Table();
            pane.ContentContainer.Controls.Add(table);
    
            // top row
            tr = new TableRow();
            // cells
            TableHeaderCell th = new TableHeaderCell();
            th.Width = 440;
            th.Text = "Provision";
            // set other properties
            tr.Controls.Add(th);
            // create next control
            th = new TableHeaderCell();
            th.Width = 120;
            th.Text = "Mark for Review";
            // set other properties
            tr.Controls.Add(th);
            // etc for other columns
            table.Controls.Add(tr);
    
        }
    
        tr = new TableRow();
        TableCell tc = new TableCell();
        tc.Text = dt.Rows[i]["Provision"].ToString();
        tr.Controls.Add(tc);
        tc = new TableCell();
        tc.Text = dt.Rows[i]["MarkForReview"].ToString();
        tr.Controls.Add(tc);
        // etc for other columns
        // add the button
        tc = new TableCell();
        Button button = new Button();
        button.Text = "Edit";
        button.UseSubmitBehavior = false;
        // button.Click += btnEdit_OnClick(); // I didn't mock this
        tc.Controls.Add(button);
        tr.Controls.Add(tc);
    
        table.Controls.Add(tr);
    }
