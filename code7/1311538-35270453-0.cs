    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
          int x;
          for (x = 0; x <= 100; x++)
          {
            ListItem item = new ListItem(x.ToString(),x.ToString());
            tidalqty.Items.Add(item);
            meatyqty.Items.Add(item);
            darknessqty.Items.Add(item);
            macaroniqty.Items.Add(item);
            cheesyqty.Items.Add(item);
            baconqty.Items.Add(item);
            loveqty.Items.Add(item);
          }       
        } 
    }
