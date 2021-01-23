    protected void Page_Load(object sender, EventArgs e)
    {
           
         if (lblfield.SelectedValue == "OrderDate")
         {
              txtsearch.Visible = false;
         }
         else
         {
              txtsearch.Visible = true;
         }
    }
