    private int rowCount = 1;
    private bool rowNeeded = false;
        
    protected override void OnPreInit(EventArgs e)
    {
        //Pre-emptively create additional row on post back.
        //We'll remove it if we don't need it later
        //Controls Have to be added at pre-init to maintain their view state
        //Adding a row in the button click event will result in any data 
        //entered in that row dissapearing from viewstate on next post back
        if (IsPostBack)
        {
            //Get number of additional rows from hidden field
            //We're using a hidden form field and Request.Form
            //instead of ViewsState and hdnRowCount.value
            //because ViewState has not been loaded at this stage
            //of the page life cycle
            if (!string.IsNullOrEmpty(Request.Form["hdnRowCount"]))
            {
                rowCount = int.Parse(Request.Form["hdnRowCount"]);
            }
            for (int i = 0; i < rowCount; i++)
            {
                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                TextBox tb = new TextBox();
                // +2 as there are existing controls with "1", eg txt1
                tb.ID = string.Format("txt{0}",i+2);
                tc.Controls.Add(tb);
                tr.Cells.Add(tc);
                Table1.Rows.Add(tr);
            }
                
        }
            
        base.OnPreInit(e);
    }        
       
      
    //Add Row Click
    protected void Button1_Click(object sender, EventArgs e)
    {            
        //Hold number of additional rows in hidne field
        hdnRowCount.Value = (++rowCount).ToString();
        //Let the page know we need to keep the row
        rowNeeded = true;            
    }
    //An Exmple of how to get your data out
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string s = "";
        //Iterate through the table rows finding the controls
        //Using count -1 as we still have the pre-emptive row
        for(int i = 0; i < Table1.Rows.Count-1; i++)
        {
            TextBox tb = (TextBox)Table1.Rows[i].FindControl(string.Format("txt{0}",i+1));
            s += "," + tb.Text;
        }
        lblResult.Text = s;
        lblResult.Visible = true;
           
    }
    protected override void OnLoadComplete(EventArgs e)
    {
        //Get rid of pre-emptive row if we don't need it
        if (IsPostBack)
        {
            if (!rowNeeded)
            {
                Table1.Rows.RemoveAt(Table1.Rows.Count - 1);
            }
        }
        base.OnLoadComplete(e);
    }
