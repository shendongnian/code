    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack)
      {
        ListBox1.Items.Clear();
        List<Lekarna> lekarne = service.pridobiLekarne().ToList();
        foreach (Lekarna a in lekarne)
        {
            ListBox1.Items.Add(a.ID + " | " + a.imeLekarne + " | " + a.Kraj + " | " 
                                    + a.Država + Environment.NewLine);
        }
      }
    }
