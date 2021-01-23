     private void button1_Click(object sender, EventArgs e)
            {
                if (passControl != null)
                {
                    passControl(txtName.Text,int.Parse(txt1.Text),int.Parse(txt2.Text),int.Parse(txt3.Text));
                }
            }
