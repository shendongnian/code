    for (int i = 0; i < GridView2.Rows.Count; i++)
    {
        string Health_Comment_Status;
        Health_Comment_Status = GridView2.Rows[i].Cells[3].Text; // here you go vr =   the value of the cel
        if (Health_Comment_Status  == "R") // you can check for anything
        {
            GridView2.Rows[i].Cells[3].Text = "Rejected";
            // you can format this cell 
        }
        else
       { 
        GridView2.Rows[i].Cells[3].Text = "Accepted";
       }
    }
