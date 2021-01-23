    FlowLayoutPanel flowLayoutPanel = ...; // define this in the designer
    
    foreach(var v in items)
    {
        GroupBox gb = new GroupBox();
        gb.Text = "Item";
    
        Label label = new Label();
        label.Text = v.Name;
        gb.Controls.Add(label);
    
        Button btn = new Button();
        btn.Text = v.Price.ToString();
        gb.Controls.Add(btn);
    
        flowLayoutPanel.Controls.Add(gb);
    }
