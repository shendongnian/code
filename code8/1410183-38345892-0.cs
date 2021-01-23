    protected void Button_Click(object sender, EventArgs e)
    {
         RadButton btn = sender as RadButton;
         switch (btn.ID)
         {
             case "btnStandardConfirm":
             Label1.Text = "The <strong>StandardButton</strong> submitted the page at: " + DateTime.Now.ToString();
             break;
         }
     }
