           TableHeaderRow thead = new TableHeaderRow();
                        TableHeaderCell th = new TableHeaderCell();
                        th.Controls.Add(new LiteralControl("Object Wise Detail(s)"));
                        th.RowSpan = 2;
                        thead.Cells.Add(th);
                        int totalUsers = accesswiseDt.Rows.Count;
        
                        for (int User = 0; User < totalUsers; User++)
                        {
                            TableHeaderCell th2 = new TableHeaderCell();
                            th2.Controls.Add(new LiteralControl(accesswiseDt.Rows[User]["users"].ToString()));
                            IsReviewPending = view_access.IsWaitingForViewAccess(ApplicationTree.SelectedNode.Value, Session["empCode"].ToString(), accesswiseDt.Rows[User]["empcode"].ToString());
                            if (IsReviewPending)
                            {
                                th2.Controls.Add(new LiteralControl("<br />"));
                                CanReviewAccess = true;
    //Code for Adding Dynamic control in specific cell of the table
                                CheckBox chk = new CheckBox();
                                chk.ID = ApplicationTree.SelectedNode.Value + "_" + accesswiseDt.Rows[User]["empcode"].ToString();
                                chk.Text = "Access Reviewed";
                                th2.Controls.Add(chk);
        
                            }
        
                            thead.Cells.Add(th2);
                        }
                       
