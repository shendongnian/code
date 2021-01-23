    protected void Page_Load(object sender, EventArgs e)
            {
                Button btn = new Button();
                btn.Click += btn_Click;
                btn.CommandArgument = "12"; //<-- you can pass argument like this
                divUserUploadedList.Controls.Add(btn);
    
            }
    
            void btn_Click(object sender, EventArgs e)
            {
                Button btn = sender as Button;
                string value = btn.CommandArgument;
            }
