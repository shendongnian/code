            private void button1_Click(object sender, EventArgs e)
            {
                if (textBox1.Text == "12345")
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
