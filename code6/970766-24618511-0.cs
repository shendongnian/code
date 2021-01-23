    protected void GridView1_RowData(object sender,GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.Footer)
       {
          TableRow tr = new TableRow();
    
          TableCell cell1 = new TableCell();
          cell1.Text = "A Button";
    
          TableCell cell2 = new TableCell();
          Button button = new Button();
 
          button.ID = "button1";
          button.Text = "Click me!";
          button.Click += new EventHandler(button_Click);
          cell2.Controls.Add(button);
    
          e.Row.Cells.Clear();
          e.Row.Cells.Add(cell1);
          e.Row.Cells.Add(cell2);
    
        }    
    }
    protected void button_Click(object sender, EventArgs e)
    {
       String text = e.ToString();
    }
