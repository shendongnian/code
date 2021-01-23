    foreach (DataRow dr in dt.Rows)
    {
        var btn = new Button();
      
        btn.Text = "val1";
        btn.ID = dr.ItemArray[0].ToString();
     
        btn.Click += (sd, ev) => {
             // it is not htmlinput anymore as i used a server side control.
             string id = ((Button) sender).ID;
            // some other code using id 
        };
        CNT.Controls.Add(btn);
    } 
