    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Loop throught your number of rows from gridview data
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                //Datetime from your gridview column no.4 (0,1,2,3)
                DateTime date_patched = Convert.ToDateTime(GridView2.Rows[i].Cells[3].Text);
                
                //Here you need to modify
                //if date_patched older than 30 days and later than 60 days
                 if(date_patched < DateTime.Now.AddDays(-30) && date_patched > DateTime.Now.AddDays(-60)) 
                 { 
                     //do something
                     GridView2.Rows[i].Cells[3].BackColor = System.Drawing.Color.Red;
                 }
                 //if older than 60days 
                 else if (date_patched < DateTime.Now.AddDays(-60))     
                 {
                     //do something
                 }
            }
