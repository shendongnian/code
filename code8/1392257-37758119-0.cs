    private void button2_Click_1(object sender, EventArgs e)
    
    {
    
    try
    
    {
    
    StringBuilder sb = new StringBuilder();
    
    sb.AppendLine(textBox1.Text + " " + textBox2.Text+ " " + textBox3.Text+ " " + textBox4.Text);
    sb.AppendLine((Int32.Parse(textBox1.Text) + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox3.Text)).ToString())
    
                File.WriteAllText(fileName, sb.ToString());
    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
