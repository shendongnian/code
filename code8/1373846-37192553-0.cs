    protected void UpdateItems(object sender, EventArgs e)
        {
              UpdateItems.Text = "Done!";
              var mp = this.Page.MasterPage;
              var up = mp.FindControl("Panel11");
              var hl = up.FindControl("Items");
              //do something with hl
              up.Update(); //if updateMode="Conditional"
              // can't use Items.Text = "1" or similar due to this being a separate control
        }
