    Button button2 = new Button();
    
    button2.Text = "buy";
    button2.ID = ddr[2].ToString();
    button2.CssClass = "btn"; //add a css class
    
    button2.Click += new System.EventHandler(detail_Click);
    Panelproduct.Controls.Add(button2);
