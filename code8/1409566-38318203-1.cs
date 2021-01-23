    protected void Page_Init(object sender, EventArgs e)
    {
        var list = Session["lstObjects"] as List<Line>;
        if (list != null)
        {
            foreach (var obj in list)
            {
                ImageButton imageButton = new ImageButton {ID = obj.ToString()};
                imageButton.Click += cmdChangeColor_Click;
                pnlButtons.Controls.Add(imageButton);
            }
        }
    }
