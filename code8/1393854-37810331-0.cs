         protected void grv_Data_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grv_Data.PageIndex = e.NewPageIndex;
           if(status==1) //Search button is already clicked, means the grid contains searched result
            {
               grv_Data.DataSource = tit.SelectList( fromDate, toDate);
            }
          else
            {
             //Search button is not clicked .. means the grid contains all records.
               TicketDataBinding();
            }
    }
