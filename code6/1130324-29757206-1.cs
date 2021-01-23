    private void Form1_Load(object sender, EventArgs e)
            {
                btnControl Control = new btnControl();
                this.Controls.Add(Control);
                Control.label.Text = "Home";
                Control.box.Text = "42";
            }
