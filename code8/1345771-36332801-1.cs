    void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == Repeater1.AlternatingItem || e.Item.ItemType == Repeater1.Item)
        {
            var btn = e.Item.FindControl("btnSave") as Button;
            if (btn != null)
            {  // adding button event 
                btn.Click += new EventHandler(btn_Click);
            }
        }
    }
    void btn_Click(object sender, EventArgs e)
    {
     //write your code 
    }
 
