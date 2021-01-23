    protected void Page_Load(object sender, EventArgs e)
    {
      if(!IsPostBack) {
        Button bb = new Button();
        bb.Text = "Buttoninpageload";
        this.Panel2.Controls.Add(bb);
        bb.Click += new EventHandler(bb_Click);
      }
    }
