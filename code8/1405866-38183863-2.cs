    private void Form1_Load(object sender, EventArgs e)
        {
            int a = 10;
            for (int i = 1; i < 5; i++)
            {
                TextBox txtbx;
                txtbx = new TextBox();
                txtbx.Location = new Point(10, a);
                txtbx.KeyDown += Txtbx_KeyDown; //Added
                txtbx.TabIndex = i;  //Added
                a += 30;
                this.Controls.Add(txtbx);
                if (i == 1)
                {
                    txtbx.Focus();
                }
            }
        }
