    //formatting for the rows
    int oddNumber = 1;
    //declate the button
    Button btn_continue
    foreach (DataRow row in dtGetIncompleteJobs.Rows)
    {
        //grab the date and make it shorter
        DateTime date = Convert.ToDateTime(row[3].ToString());
        
        //create the button
        btn_continue = new Button();
        btn_continue.Click += Btn_continue_Click;
        btn_continue.CssClass = "controlButtons";
        btn_continue.Font.Size = 20;
        btn_continue.Text = "Continue this job";
        
        pnl_jobList.Controls.Add(new LiteralControl("<tr>"));
        if (centralFunctions.OddNumberCheck(oddNumber) == true)
        {
            pnl_jobList.Controls.Add(new LiteralControl("<td class='col-1 col-1-m lightRow'>" + row[5].ToString() + "</td>"));
            pnl_jobList.Controls.Add(new LiteralControl("<td class='col-2 col-2-m lightRow'>" + date.ToShortDateString() + "</td>"));
            pnl_jobList.Controls.Add(new LiteralControl("<td class='col-2 col-2-m lightRow'>" + row[0].ToString() + "</td>"));
            pnl_jobList.Controls.Add(new LiteralControl("<td class='col-2 col-2-m lightRow'>" + row[1].ToString() + "</td>"));
            pnl_jobList.Controls.Add(new LiteralControl("<td class='col-2 col-2-m lightRow'>" + row[2].ToString() + "</td>"));
            pnl_jobList.Controls.Add(new LiteralControl("<td class='col-1 col-1-m lightRow'>" + row[4].ToString() + "</td>"));
            pnl_jobList.Controls.Add(new LiteralControl("<td class='col-2 col-2-m'>"));
            btn_continue.ID = row[5].ToString();
            pnl_jobList.Controls.Add(btn_continue);
            pnl_jobList.Controls.Add(new LiteralControl("</td>"));
            oddNumber++;
        }
        else
        {
            pnl_jobList.Controls.Add(new LiteralControl("<td class='col-1 col-1-m darkRow'>" + row[5].ToString() + "</td>"));
            pnl_jobList.Controls.Add(new LiteralControl("<td class='col-2 col-2-m darkRow'>" + row[3].ToString() + "</td>"));
            pnl_jobList.Controls.Add(new LiteralControl("<td class='col-2 col-2-m darkRow'>" + row[0].ToString() + "</td>"));
            pnl_jobList.Controls.Add(new LiteralControl("<td class='col-2 col-2-m darkRow'>" + row[2].ToString() + "</td>"));
            pnl_jobList.Controls.Add(new LiteralControl("<td class='col-2 col-2-m darkRow'>" + row[2].ToString() + "</td>"));
            pnl_jobList.Controls.Add(new LiteralControl("<td class='col-1 col-1-m darkRow'>" + row[4].ToString() + "</td>"));
            pnl_jobList.Controls.Add(new LiteralControl("<td class='col-2 col-2-m'>"));
            btn_continue.ID = row[5].ToString();
            pnl_jobList.Controls.Add(btn_continue);
            pnl_jobList.Controls.Add(new LiteralControl("</td>"));
            oddNumber++;
        }
        pnl_jobList.Controls.Add(new LiteralControl("</tr>"));
    }
