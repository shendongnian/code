        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TextBox txt = new TextBox();
            txt.KeyPress += Txt_KeyPress; // attach event handler to textbox created at runtime.
            tableLayoutPanel1.Controls.Add(txt);
        }
