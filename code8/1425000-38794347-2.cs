    Table table = null;
    
    string BranchName = null;
    
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        TableRow tr;
        if (BranchName != dt.Rows[i]["Category"].ToString())
        {
            BranchName = dt.Rows[i]["Category"].ToString();
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
            // set properties like class, height .. etc
            table.CssClass = "hoverTable";
            // add it to a container
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
        button.Click += new EventHandler(btnEdit_OnClick);
        tc.Controls.Add(button);
        tr.Controls.Add(tc);
    
        table.Controls.Add(tr);
    }
