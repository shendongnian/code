            Table t = new Table(); 
            TableRow tr = new TableRow(); 
            TableCell tc = new TableCell();
            System.Web.UI.WebControls.TextBox tb = new  System.Web.UI.WebControls.TextBox() { Text = "Testing" };
            tc.Controls.Add(tb); //Add Textbox to TableCell Control Collection
            tr.Cells.Add(tc); // Add TableCell to TableRow
            t.Rows.Add(tr); //Add TableRow to Table
            System.Web.UI.WebControls.Panel panel = new System.Web.UI.WebControls.Panel(); //This is your panel
            panel.Controls.Add(t); // Add Table to Panel
            Table tbl = panel.Controls.OfType<Table>().FirstOrDefault(); //Now to find the TextBox in the Table, in the Row, in the cell
    
            foreach (TableRow row in tbl.Rows) //Loop through each TableRow
            {
                foreach (TableCell cell in row.Cells)     //Loop through each TableCell
                {
                    IEnumerable<System.Web.UI.WebControls.TextBox> txtBoxes = cell.Controls.OfType<System.Web.UI.WebControls.TextBox>(); //Search TableCell.Controls Collection for all TextBoxes
                }
            }
