      protected void Page_Load(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.ID = "MyId";
            btn.Click += MyEvent;
            
           tabellaDownload.Controls.Add(btn);
        }
        protected void MyEvent(object sender, EventArgs e)
        {
        }
