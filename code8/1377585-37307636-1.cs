    int j = 0;
    for (TimeSpan i = new TimeSpan(10, 0, 0); i.ToString(@"hh\:mm") != "12:00"; i = i.Add(new TimeSpan(0, 15, 0)), j++)
    {
        Button btn1 = new Button();
        btn1.ID = "btn" + j;
        btn1.Text = i.ToString(@"hh\:mm");
        btn1.Click += new EventHandler(btn1_Click);
        div1.Controls.Add(btn1);
        Label lbl = new Label();
        lbl.Text = i.ToString(@"hh\:mm");
        div1.Controls.Add(lbl);
        Console.WriteLine(i.ToString(@"hh\:mm"));
    }
    void btn1_Click(object sender, EventArgs e)
    {
        string buttonId = ((Button)sender).ID;
        div1.InnerHtml += "Button: " + buttonId + " was clicked";
    }
