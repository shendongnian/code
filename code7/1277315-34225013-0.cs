    private void MyForm_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox1.Focused) // or whatever your textbox is called
                    {
                        buttonSearch_Click(sender, e);   
                    }
                }
                    
            }
