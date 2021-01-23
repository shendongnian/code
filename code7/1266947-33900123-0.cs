    protected void Page_Load(object sender, EventArgs e)
    {
        if(!this.IsPostback)
            BuildCheckBoxes();
    }
    private void BuildCheckBoxes()
    {
        foreach (string filename in filepaths)
        {
          CheckBox chk = new CheckBox();
          chk.Text = Path.GetFileName(filename.ToString());
          Panel1.Controls.Add(chk);
          Panel1.Controls.Add(new LiteralControl("<br>"));                  
        }
    }
