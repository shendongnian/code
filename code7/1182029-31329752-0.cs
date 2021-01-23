    protected void Page_Load(object sender, EventArgs e)
        {
            Button b = new Button();
            b.ID = "one";
            b.Text = "one";
            b.Click += B_Click;
            this.form1.Controls.Add(b);
            
            // this is where the dynamic control is created if id is in postback
            if (Request["two"] != null)
            {
                Button x = new Button();
                x.ID = "two";
                x.Text = "two";
                x.Click += X_Click;
                this.form1.Controls.Add(x);
            }
        }
        private void B_Click(object sender, EventArgs e)
        {
            Button x = new Button();
            x.ID = "two";
            x.Text = "two";
            x.Click += X_Click;
            this.form1.Controls.Add(x);
            LabelOutput.Text += " ...one";
            
        }
        private void X_Click(object sender, EventArgs e)
        {
            LabelOutput.Text += " ...two";
        }
