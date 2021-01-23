        private void Form1_Load(object sender, EventArgs e)
        {
            Button button = new Button();
            button.Text = "Button1";
            button.Location = new Point(0, 10);
            splitContainer2.Panel2.Controls.Add(button);
            button = new Button();
            button.Text = "Button2";
            button.Location = new Point(0, 50);
            splitContainer2.Panel2.Controls.Add(button);
        }
