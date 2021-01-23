    private void button2_Click(object sender, EventArgs e)
            {
                try
                {
                    Form2 frm2 = new Form2();
                    frm2.ControlText = Text1.text
                    frm2.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
