    protected void Page_Init(object sender, EventArgs e) 
    {
       var list = Session["lstObjects"] as List<Line>;
       if(list != null) 
       {
          foreach (object obj in (()))
          {
            ImageButton imageButton = new ImageButton();
            imageButton.ID = obj.ToString();
            imageButton.Click += cmdChangeColor_Click;
            pnlButtons.Controls.Add(imageButton);
          }
      }
    }
