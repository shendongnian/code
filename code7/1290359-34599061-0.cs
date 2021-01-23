    protected void myFunction()
    {
    int NoofItems = tillfrm.lvbasket.Items.Count;  
        for (int i = 0; i < NoofItems; i++)  
        {  
        Label lblitems = new Label();  
        lblitems.Name = "lblItems" + i;  
        lblitems.Font = new Font ("Calibri",lblitems.Font.Size);  
        lblitems.Location = new Point(95, (152 + (19 * i)));  
        lblitems.ForeColor = System.Drawing.Color.Black;  
        lblitems.Show();  
        lblitems.AutoSize = true;  
        lblitems.Text = tillfrm.lvbasket.Items[i].Text;  
        this.Controls.Add(lblitems);  
        }
    }
