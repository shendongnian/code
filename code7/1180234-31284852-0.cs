    protected void Page_Load(object sender, EventArgs e)
    {
      CommonDataGrid.Visible=true;
      PlaceHolder1.Controls.Add(CommonDataGrid);
      PlaceHolder2.Controls.Add(CommonDataGrid);
    }
